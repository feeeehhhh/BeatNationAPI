//using src.features.License.Command.Validators;
using DotNetEnv;
using src.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using src.Models;
using Microsoft.AspNetCore.Identity;
using src.app.Repository;
using src.app.Configurations;
using Resend;
using src.features.Interface.Beats.Command;
using src.features.Interface.Email.Command;
using src.features.Email.Handler;
using src.features.Autentication.Handler;

Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Conecxão com o banco de dados
Environment.GetEnvironmentVariable("CONNECT_SQL");
var ConnectSQL = Environment.GetEnvironmentVariable("CONNECT_SQL");
Console.WriteLine($"CONNECT_SQL: {ConnectSQL}");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(ConnectSQL));
;
var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer(ConnectSQL)
    .Options;

var retryCount = 15; // mais tentativas
while (retryCount > 0)
{
    try
    {
        using var context = new AppDbContext(options);
        context.Database.Migrate();
        Console.WriteLine("Banco conectado e migrations aplicadas!");
        break;
    }
    catch (Exception ex)
    {
        retryCount--;
        Console.WriteLine($"SQL ainda n�o pronto, tentando novamente em 5s... Erro: {ex.Message}");
        Thread.Sleep(5000);
    }
}

if (retryCount == 0)
{
    throw new Exception("N�o foi poss�vel conectar ao SQL Server ap�s v�rias tentativas.");
}


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true; // deixa o JSON legível
        options.JsonSerializerOptions.MaxDepth = 32;        // aumenta profundidade para testar
    });


builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);

});

builder.Services.AddOpenApi();

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });

});
// EnvConfig

var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
EnvConfig.Load(dotenv);

builder.Configuration["Cloudflare:AccountId"] = Environment.GetEnvironmentVariable("CLOUDFLARE_ACCOUNTID");
builder.Configuration["Cloudflare:AccessKeyId"] = Environment.GetEnvironmentVariable("CLOUDFLARE_ACCESSKEYID");
builder.Configuration["Cloudflare:SecretAccessKey"] = Environment.GetEnvironmentVariable("CLOUDFLARE_SECRETACCESSKEY");
builder.Configuration["Cloudflare:Bucket"] = Environment.GetEnvironmentVariable("CLOUDFLARE_BUCKET");
builder.Configuration["Cloudflare:PublicDomain"] = Environment.GetEnvironmentVariable("CLOUDFLARE_PUBLICDOMAIN");

// Configuração do Identity
builder.Services
    .AddIdentity<User, IdentityRole<Guid>>(opitions =>
    {
        opitions.Password.RequireDigit = true;
        opitions.Password.RequireLowercase = true;
        opitions.Password.RequireNonAlphanumeric = true;
        opitions.Password.RequireUppercase = true;
        opitions.Password.RequiredLength = 6;

        opitions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
        opitions.Lockout.MaxFailedAccessAttempts = 5;
        opitions.Lockout.AllowedForNewUsers = true;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Configura CORS para permitir requisições do frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:3000") // origem do frontend
                .AllowAnyHeader()
                .AllowAnyMethod();

        });
});

// JWT
var keyString = Environment.GetEnvironmentVariable("PRIVATE_KEY");
if (string.IsNullOrEmpty(keyString))
    throw new Exception("PRIVATE_KEY não definida!");

var key = Encoding.ASCII.GetBytes(keyString);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.ContainsKey("accessToken"))
            {
                context.Token = context.Request.Cookies["accessToken"];
            }
            return Task.CompletedTask;
        }
    };

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "AuthAPI",
        ValidAudience = "BeatNationAPI",
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization(); // necessário para [Authorize]

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT com Bearer",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme { Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }},
            new string[]{}
        }
    });
});
// Resend Email Service
builder.Services.Configure<ResendOptions>(
    builder.Configuration.GetSection("Resend")
);
builder.Services.AddOptions();

builder.Services.AddHttpClient<ResendClient>();

var resendAPIKey = Environment.GetEnvironmentVariable("KEY_RESENDEMAIL");
var resendFrom = Environment.GetEnvironmentVariable("FROM_EMAIL");
builder.Services.Configure<ResendClientOptions>(o =>
{
    o.ApiToken = resendAPIKey;
});
builder.Services.Configure<ResendOptions>(options =>
{
    options.FromEmail = resendFrom!;
});

builder.Services.AddTransient<IResend, ResendClient>();

builder.Services.AddScoped<IEmailService, ResendEmailService>();

builder.Services.AddScoped<TokenService>();

builder.Services.AddScoped<IBeatRepository, BeatRepository>();

var app = builder.Build();

// Seed do banco de dados
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DbSeeder.SeedAsync(services);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1"));
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();


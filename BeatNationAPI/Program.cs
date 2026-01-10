<<<<<<< HEAD
﻿using BeatNationAPI.Data;

=======
﻿using BeatNationAPI.Application.Licencas.Command.Validators;
using BeatNationAPI.Data;
using FluentValidation;
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Conecx�o com o banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:SQL"]));

var connectionString = builder.Configuration["ConnectionStrings:SQL"];
var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer(connectionString)
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

builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(Program).Assembly); });

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

<<<<<<< HEAD
builder.Configuration["Cloudflare:AccountId"] = Environment.GetEnvironmentVariable("CloudFlare_AccountId");
builder.Configuration["Cloudflare:AccessKeyId"] = Environment.GetEnvironmentVariable("CloudFlare_AccessKeyId");
builder.Configuration["Cloudflare:SecretAccessKey"] = Environment.GetEnvironmentVariable("CloudFlare_SecretAccessKey");
builder.Configuration["Cloudflare:Bucket"] = Environment.GetEnvironmentVariable("CloudFlare_Bucket");
builder.Configuration["Cloudflare:PublicDomain"] = Environment.GetEnvironmentVariable("CloudFlare_PublicDomain");
=======
builder.Configuration["Cloudflare:AccountId"] = Environment.GetEnvironmentVariable("CLOUDFLARE_ACCOUNTID");
builder.Configuration["Cloudflare:AccessKeyId"] = Environment.GetEnvironmentVariable("CLOUDFLARE_ACCESSKEYID");
builder.Configuration["Cloudflare:SecretAccessKey"] = Environment.GetEnvironmentVariable("CLOUDFLARE_SECRETACCESSKEY");
builder.Configuration["Cloudflare:Bucket"] = Environment.GetEnvironmentVariable("CLOUDFLARE_BUCKET");
builder.Configuration["Cloudflare:PublicDomain"] = Environment.GetEnvironmentVariable("CLOUDFLARE_PUBLICDOMAIN");
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)




// Configura CORS para permitir requisições do frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:3000") // origem do frontend
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); // só se estiver usando cookies/autenticação
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

<<<<<<< HEAD
=======
builder.Services.AddValidatorsFromAssembly(typeof(PresetCreateValidator).Assembly);
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)

var app = builder.Build();
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

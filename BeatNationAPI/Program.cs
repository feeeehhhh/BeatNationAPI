using BeatNationAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

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

builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(Program).Assembly); });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });

});

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using BeatNationAPI.Data;
using Microsoft.EntityFrameworkCore;

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
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

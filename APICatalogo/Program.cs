using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configurar o "Context" para se comunicar com o banco de dados
string SqlConnection = builder.Configuration.GetConnectionString("ConexaoPadrao");

builder.Services.AddDbContext<ApiCatalogoContext>(options => options.UseMySql(SqlConnection, 
    ServerVersion.AutoDetect(SqlConnection)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inserir a string que conex�o
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

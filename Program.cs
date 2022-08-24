using ADOAPI.Models;
using ADOAPI.Services.Interfaces;
using ADOAPI.Services.Logica;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Inyeccion para que lea los modelos con el patron de servicios/repositorios
builder.Services.AddScoped<IUsuarios, UsuarioLogica>();
builder.Services.AddScoped<IDestinos, DestinoLogica>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

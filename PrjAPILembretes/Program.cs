using Microsoft.EntityFrameworkCore;
using PrjAPILembretes.Context;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

//Adicionando referência à connection string
builder.Services.AddDbContext<AppLembretesContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("ConexaoPadrao")));
//Chamando o construtor da classe AppLembretes

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

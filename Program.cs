using Projeto_back.Data;
using Projeto_back.Repositorios;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DataBase");
builder.Services.AddDbContext<AlunoContext>(options =>
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1", builder =>
    {
        builder.WithOrigins("https://localhost:7110",
    "http://localhost:80")
    .AllowAnyHeader()
    .AllowAnyMethod().SetIsOriginAllowedToAllowWildcardSubdomains();
    }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Policy1");

app.UseAuthorization();

app.MapControllers();

app.Run();

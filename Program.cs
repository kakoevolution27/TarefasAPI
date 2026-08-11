using Microsoft.EntityFrameworkCore;
using TarefasApi.Data;
using TarefasAPI.Repositories;
using TarefasAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

string? strDeConexao = builder.Configuration.GetConnectionString("StringConexaoPostgres");



builder.Services.AddDbContext<TarefasApiContext>(options => options.UseNpgsql(strDeConexao));

builder.Services.AddScoped<CategoriaRepository>();

builder.Services.AddScoped<CategoriaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();



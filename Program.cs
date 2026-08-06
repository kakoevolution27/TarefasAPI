using Microsoft.EntityFrameworkCore;
using TarefasApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

string strDeConexao = builder.Configuration.GetConnectionString("ConnectionStrings") ?? "";


builder.Services.AddDbContext<TarefasApiContext>(options => options.UseNpgsql(strDeConexao));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();



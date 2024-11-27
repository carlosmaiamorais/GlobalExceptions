using GlobalExceptionHandler.API.CrossCutting;
using GlobalExceptionHandler.API.Services;
using GlobalExceptionHandler.API.Services.Interfaces;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddExceptionHandler<ApiExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseExceptionHandler(_ => { });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
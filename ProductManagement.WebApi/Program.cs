using FluentValidation;
using ProductManagement.Application.Validations;
using ProductManagement.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

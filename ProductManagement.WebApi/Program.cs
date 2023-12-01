using FluentValidation;
using ProductManagement.Domain.Entities;
using ProductManagement.Application.Repositories;
using ProductManagement.Application.Services;
using ProductManagement.Application.Validations;
using ProductManagement.Infrastructure.Data;
using ProductManagement.Infrastructure.Repositories;
using ProductManagement.Infrastructure.Services;
using ProductManagement.WebApi.Modules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();

builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(MongoDBBaseRepository<>));
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//API Endpoints
app.AddCategoriesEndpoints();
app.AddProductsEndpoints();

app.UseHttpsRedirection();

app.Run();

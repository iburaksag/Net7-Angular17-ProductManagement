using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Repositories;
using ProductManagement.Application.Services;
using ProductManagement.Domain.Entities;

namespace ProductManagement.WebApi.Modules
{
    public static class ProductsModule
    {
        public static void AddProductsEndpoints(this IEndpointRouteBuilder app)
        {
            //GET ALL
            app.MapGet("/api/v1/products", async (IProductService _productService, HttpContext context) =>
            {
                var products = await _productService.GetAllAsync();
                await JsonSerializer.SerializeAsync(context.Response.Body, products, options: null);
            });

            //GET BY ID
            app.MapGet("/api/v1/products/{id}", async (IProductService _productService, string id, HttpContext context) =>
            {
                var product = await _productService.GetByIdAsync(id);
                if (product is not null)
                    await JsonSerializer.SerializeAsync(context.Response.Body, product, options: null);
                else
                    Results.NotFound();
            });

            //GET PRODUCTS BY CATEGORY ID
            app.MapGet("/api/v1/products/category/{categoryId}", async (IProductService _productService, string categoryId, HttpContext context) =>
            {
                var products = await _productService.GetProductsByCategoryIdAsync(categoryId);
                await JsonSerializer.SerializeAsync(context.Response.Body, products, options: null);
            });

            //create
            app.MapPost("/api/v1/products", async (IProductService _productService, [FromBody] Product product) =>
            {
                await _productService.CreateAsync(product);
                Results.Created($"/api/v1/products/{product.Id}", product);
            });


            //update
            app.MapPut("/api/v1/products/{id}", async (IProductService _productService, string id, [FromBody] Product updatedProduct) =>
            {
                await _productService.UpdateAsync(id, updatedProduct);
                return Results.NoContent();
            });


            //delete
            app.MapDelete("/api/v1/products/{id}", async (IProductService _productService, string id) =>
            {
                await _productService.DeleteAsync(id);
                Results.NoContent();
            });

        }
    }
}


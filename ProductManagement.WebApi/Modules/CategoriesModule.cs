using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Repositories;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Services;

namespace ProductManagement.WebApi.Modules
{
    public static class CategoriesModule
    {
        public static void AddCategoriesEndpoints(this IEndpointRouteBuilder app)
        {
            //GET ALL
            app.MapGet("/api/v1/categories", async (CategoryService categoryService, HttpContext context) =>
            {
                var categories = await categoryService.GetAllAsync();
                await JsonSerializer.SerializeAsync(context.Response.Body, categories, options: null);
            });

            //GET BY ID
            app.MapGet("/api/v1/categories/{id}", async (CategoryService categoryService, string id, HttpContext context) =>
            {
                var category = await categoryService.GetByIdAsync(id);
                if (category is not null)
                    await JsonSerializer.SerializeAsync(context.Response.Body, category, options: null);
                else
                    Results.NotFound();
            });

            //create
            app.MapPost("/api/v1/categories", async (CategoryService categoryService, [FromBody] Category category) =>
            {
                await categoryService.CreateAsync(category);
                Results.Created($"/api/v1/categories/{category.Id}", category);
            });


            //update
            app.MapPut("/api/v1/categories/{id}", async (CategoryService categoryService, string id, [FromBody] Category updatedCategory) =>
            {
                await categoryService.UpdateAsync(id, updatedCategory);
                return Results.NoContent();
            });


            //delete
            app.MapDelete("/api/v1/categories/{id}", async (CategoryService categoryService, string id) =>
            {
                await categoryService.DeleteAsync(id);
                Results.NoContent();
            });

        }
    }
}


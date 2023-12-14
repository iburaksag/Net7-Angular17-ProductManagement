using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Services;
using ProductManagement.Domain.Entities;

namespace ProductManagement.WebApi.Modules
{
    public static class CategoriesModule
    {
        public static void AddCategoriesEndpoints(this IEndpointRouteBuilder app)
        {
            //GET ALL
            app.MapGet("/api/v1/categories", async (ICategoryService categoryService, HttpContext context) =>
            {                
                var categories = await categoryService.GetAllAsync();
                await JsonSerializer.SerializeAsync(context.Response.Body, categories, options: null);
            });

            //GET BY ID
            app.MapGet("/api/v1/categories/{id}", async (ICategoryService categoryService, string id, HttpContext context) =>
            {
                var category = await categoryService.GetByIdAsync(id);
                if (category is not null)
                    await JsonSerializer.SerializeAsync(context.Response.Body, category, options: null);
                else
                    Results.NotFound();
            });

            //create
            app.MapPost("/api/v1/categories", async (ICategoryService categoryService, IValidator<Category> _validator, [FromBody] Category category) =>
            {
                var validationResult = await _validator.ValidateAsync(category);
                if (!validationResult.IsValid)
                {
                    return Results.ValidationProblem(validationResult.ToDictionary());
                }
                await categoryService.CreateAsync(category);
                //return Results.Created($"/api/v1/categories/{category.Id}", category);
                return Results.Ok(await categoryService.GetAllAsync());
            });


            //update
            app.MapPut("/api/v1/categories/{id}", async (ICategoryService categoryService, string id, IValidator<Category> _validator, [FromBody] Category updatedCategory) =>
            {
                var validationResult = await _validator.ValidateAsync(updatedCategory);
                if (!validationResult.IsValid)
                {
                    return Results.ValidationProblem(validationResult.ToDictionary());
                }
                await categoryService.UpdateAsync(id, updatedCategory);
                return Results.Ok(await categoryService.GetAllAsync());
            });


            //delete
            app.MapDelete("/api/v1/categories/{id}", async (ICategoryService categoryService, string id) =>
            {
                await categoryService.DeleteAsync(id);
                return Results.Ok(await categoryService.GetAllAsync());
            });

        }
    }
}


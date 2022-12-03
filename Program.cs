using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Passando a variavel de ambiente para o DbContext
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["Database:SqlServer"]);

var app = builder.Build();
var Configuration = app.Configuration;
// ProductRepository.Init(Configuration);

app.MapPost("/products", (ProductDTO ProductDTO, ApplicationDbContext context) => {
    var category = context.Categories.Where(c => c.Id == ProductDTO.CategoryId).First();

    var product = new Product {
        Code = ProductDTO.Code, 
        Name = ProductDTO.Name, 
        Description = ProductDTO.Description, 
        Category = category, 
    };

    context.Products.Add(product);
    context.SaveChanges();
    return Results.Created($"/products/{product.Id}", product.Id);
});



app.Run();



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

    if(ProductDTO.tags != null){
        product.Tags = new List<Tag>();
        foreach (var item in ProductDTO.tags) {
            product.Tags.Add(new Tag{Name = item});
        }
    }

    context.Products.Add(product);
    context.SaveChanges();
    return Results.Created($"/products/{product.Id}", product.Id);
});


app.MapGet("/products/{id}", ([FromRoute] int id, ApplicationDbContext context) => {
    var product = context.Products
        .Include(p => p.Category)
        .Include(p => p.Tags)
        .Where(p => p.Id == id).First();
    if(product != null){
        return Results.Ok(product);
    }
    return Results.NotFound();

});


app.MapPut("/products/{id}", ([FromRoute] int id, ProductDTO ProductDTO, ApplicationDbContext context) => {
   var product = context.Products
        .Include(p => p.Tags)
        .Where(p => p.Id == id).First();

    var category = context.Categories.Where(c => c.Id == ProductDTO.CategoryId).First();

    product.Code = ProductDTO.Code;
    product.Name = ProductDTO.Name; 
    product.Description = ProductDTO.Description; 
    product.Category = category; 
    product.Tags = new List<Tag>();

    if(ProductDTO.tags != null){
        product.Tags = new List<Tag>();
        foreach (var item in ProductDTO.tags) {
            product.Tags.Add(new Tag{Name = item});
        }
    }
    context.SaveChanges();
    return Results.Ok();
});


app.MapDelete("/products/{id}", ([FromRoute] int id, ApplicationDbContext context) => {
    var product = context.Products.Where(p => p.Id == id).First();
    context.Products.Remove(product);
    context.SaveChanges();
    return Results.Ok();
});


app.Run();



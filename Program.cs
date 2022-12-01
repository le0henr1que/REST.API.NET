using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();
// app.MapGet("/", () => "Hello World!");
app.Run();

//teste

public class Product {
    public int Id {get; set;}
    public string? Code {get; set;}
    public string? Name {get; set;}
    public string? Description {get; set;}

}

public class ApplicationDbContext : DbContext {
    
    public DbSet<Product>? Products {get; set;} 

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost; Database=Products; User Id=sa; password=@Sql12019; MultipleActiveResultSets=true; Encrypt=YES; TrustServerCertificate=True");

}
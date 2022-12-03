using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext {
    
    public DbSet<Product>? Products {get; set;} 

    public DbSet<Category> Categories {get; set;}

    // ApplicationDbContext Variaveis de ambiente
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
        
    }

    // Escreve e define propriedades dos campos de uma tabela no banco de dadoss
    protected override void OnModelCreating(ModelBuilder builder){
        builder.Entity<Product>()
            .Property(p => p.Description).HasMaxLength(500).IsRequired(false);

        builder.Entity<Product>()
            .Property(p => p.Name).HasMaxLength(500).IsRequired();

        builder.Entity<Product>()
            .Property(p => p.Code).HasMaxLength(20).IsRequired();
            
        builder.Entity<Category>()
            .ToTable("Categories");
    }
   
}
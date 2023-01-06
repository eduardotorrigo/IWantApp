using IWantApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(60).IsRequired();
        modelBuilder.Entity<Product>().Property(c => c.Name).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Product>().Property(c => c.Description).HasMaxLength(255).IsRequired();

    }
}

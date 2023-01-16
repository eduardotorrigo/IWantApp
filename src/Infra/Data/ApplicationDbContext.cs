namespace IWantApp.Infra.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Ignore<Notification>();
        
        builder.Entity<Category>()
            .Property(c => c.Name).IsRequired();
            
        builder.Entity<Product>()
            .Property(p => p.Name).IsRequired();
        builder.Entity<Product>()
            .Property(p => p.Description).HasMaxLength(255);
        builder.Entity<Product>()
            .Property(p => p.Price).HasColumnType("decimal(10,2)").IsRequired();

            builder.Entity<Order>()
            .Property(p => p.ClientId).IsRequired();
        builder.Entity<Order>()
            .Property(p => p.DeliveryAddress).IsRequired();
        builder.Entity<Order>()
        .HasMany(o => o.Products)
        .WithMany(p => p.Orders)
        .UsingEntity(x => x.ToTable("OrderProducts"));
    }
}

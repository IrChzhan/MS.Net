using Microsoft.EntityFrameworkCore;
using MS.Net.DataAccess.Entities;

namespace MS.Net.DataAccess;

public class BookStoreDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Bucket> Buckets { get; set; }
    public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    
    public BookStoreDbContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasMany(u => u.Buckets)
            .WithMany(m => m.Books)
            .UsingEntity<Dictionary<string, object>>(
                "buckets_books",
                j => j.HasOne<Bucket>().WithMany().HasForeignKey("BucketId"), 
                j => j.HasOne<Book>().WithMany().HasForeignKey("BookId")    
            );
        
        modelBuilder.Entity<Book>()
            .HasMany(u => u.Orders)
            .WithMany(m => m.Books)
            .UsingEntity<Dictionary<string, object>>(
                "orders_books",
                j => j.HasOne<Order>().WithMany().HasForeignKey("OrderId"), 
                j => j.HasOne<Book>().WithMany().HasForeignKey("BookId")    
            );
        
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role) 
            .WithMany(r => r.Users) 
            .HasForeignKey(u => u.RoleId);
        
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Genre)
            .WithMany(g => g.Books)
            .HasForeignKey(b => b.GenreId);
        
        modelBuilder.Entity<DeliveryAddress>()
            .HasOne(d => d.User) 
            .WithMany(u => u.DeliveryAddresses) 
            .HasForeignKey(d => d.UserId);
        
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User) 
            .WithMany(u => u.Orders) 
            .HasForeignKey(o => o.UserId);
        
        modelBuilder.Entity<Book>()
            .HasOne(u => u.Author) 
            .WithMany(r => r.Books) 
            .HasForeignKey(u => u.AuthorId);
        
        modelBuilder.Entity<Payment>()
            .HasOne(u => u.PaymentMethod) 
            .WithMany(r => r.Payments) 
            .HasForeignKey(u => u.PaymentId);
    }
}
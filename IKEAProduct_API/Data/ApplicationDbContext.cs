using IKEAProduct_API.Models;
using Microsoft.EntityFrameworkCore;

namespace IKEAProduct_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<ProductColour> ProductColours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Name = "Sofa" },
                new ProductType { Id = 2, Name = "Chair" }
            );

            modelBuilder.Entity<Colour>().HasData(
                new Colour { Id = 1, Name = "Blue" },
                new Colour { Id = 2, Name = "Ruby" },
                new Colour { Id = 3, Name = "Green" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "EKTORP", ProductTypeId = 1, CreatedDate = new DateTime(2025, 06, 02) },
                new Product { Id = 2, Name = "POÄNG", ProductTypeId = 2, CreatedDate = new DateTime(2025, 06, 01) }
            );

            modelBuilder.Entity<ProductColour>().HasData(
                new { ProductId = 1, ColourId = 1 },
                new { ProductId = 1, ColourId = 2 },
                new { ProductId = 2, ColourId = 3 }
            );

            // ProductType - Product (one-to-many)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductType)
                .WithMany(pt => pt.Products)
                .HasForeignKey(p => p.ProductTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Product - Colour (many-to-many via ProductColour)
            modelBuilder.Entity<ProductColour>()
                .HasKey(pc => new { pc.ProductId, pc.ColourId });

            modelBuilder.Entity<ProductColour>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductColours)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductColour>()
                .HasOne(pc => pc.Colour)
                .WithMany(c => c.ProductColours)
                .HasForeignKey(pc => pc.ColourId);
        }
    }
}

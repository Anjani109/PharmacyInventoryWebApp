using Microsoft.EntityFrameworkCore;

namespace PharmacyInventoryWebApp.Models
{
    public class PharmacyContext : IdentityDbContext
    {
        public PharmacyContext(DbContextOptions<PharmacyContext> options)
            : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.MedicineName)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.CompanyName)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Category)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(e => e.UnitPrice)
                      .HasPrecision(10, 2);
            });
        }
    }
}

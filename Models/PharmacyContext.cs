using Microsoft.EntityFrameworkCore;
using PharmacyInventoryWebApp.Models;

namespace PharmacyInventoryWebApp.Models
{
    public class PharmacyContext : DbContext
    {
        public PharmacyContext(DbContextOptions<PharmacyContext> options)
            : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; }
    }
}


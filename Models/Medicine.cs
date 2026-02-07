using System;
using System.ComponentModel.DataAnnotations;

namespace PharmacyInventoryWebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [Required]
        public string MedicineName { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }

}

using System;
using System.ComponentModel.DataAnnotations;

namespace PharmacyInventoryWebApp.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required]
        public string SupplierName { get; set; } = string.Empty;

        public string ContactPerson { get; set; } = string.Empty;

        [Phone]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

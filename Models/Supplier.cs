using System;
using System.ComponentModel.DataAnnotations;

namespace PharmacyInventoryWebApp.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Supplier name is required")]
        [StringLength(100)]
        public string SupplierName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Person's name is required")]
        [StringLength(100)]
        public string ContactPerson { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

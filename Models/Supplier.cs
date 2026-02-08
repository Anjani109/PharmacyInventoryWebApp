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
        [Phone]
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Enter valid Indian mobile number")]
        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;
        [StringLength(200)]

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

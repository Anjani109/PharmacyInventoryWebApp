using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyInventoryWebApp.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [Required(ErrorMessage = "Medicine name is required")]
        [StringLength(100, ErrorMessage = "Medicine name cannot exceed 100 characters")]
        public string MedicineName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Company name is required")]
        [StringLength(100, ErrorMessage = "Company name cannot exceed 100 characters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required")]
        [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters")]
        public string Category { get; set; } = string.Empty;

        // Monetary values must always define precision
        [Required(ErrorMessage = "Unit price is required")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 100000, ErrorMessage = "Price must be between 0.01 and 100000")]
        public decimal UnitPrice { get; set; }

        // Soft delete / active flag
        public bool IsActive { get; set; } = true;
        public int Quantity { get; set; }        
        public DateTime ExpiryDate { get; set; }
        // Automatically set when record is created
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

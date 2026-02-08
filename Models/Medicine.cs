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
        [StringLength(100)]
        public string MedicineName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Company name is required")]
        [StringLength(100)]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required")]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;


        [Required(ErrorMessage = "Unit price is required")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 100000, ErrorMessage = "Price must be greater than 0")]
        public decimal UnitPrice { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PharmacyInventoryWebApp.Models
{
    public class CategoryReport
    {
        public string Category { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    public class ReportsViewModel
    {
        public int TotalMedicines { get; set; }
        public int ActiveMedicines { get; set; }
        public int InactiveMedicines { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

        public List<CategoryReport> Categories { get; set; } = new();
    }
}

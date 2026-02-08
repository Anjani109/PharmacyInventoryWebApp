using System.Collections.Generic;

namespace PharmacyInventoryWebApp.Models
{
    public class ReportViewModel
    {
        public int TotalMedicines { get; set; }
        public int ActiveMedicines { get; set; }
        public List<CategoryReport> Categories { get; set; }
    }

    public class CategoryReport
    {
        public string Category { get; set; }
        public int Count { get; set; }
    }
}

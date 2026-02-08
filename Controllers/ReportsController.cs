using Microsoft.AspNetCore.Mvc;
using PharmacyInventoryWebApp.Models;
using System.Linq;

public class ReportsController : Controller
{
    private readonly PharmacyContext _context;

    public ReportsController(PharmacyContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var report = new ReportViewModel
        {
            TotalMedicines = _context.Medicines.Count(),
            ActiveMedicines = _context.Medicines.Count(m => m.IsActive),
            Categories = _context.Medicines
                .GroupBy(m => m.Category)
                .Select(g => new CategoryReport
                {
                    Category = g.Key,
                    Count = g.Count()
                }).ToList()
        };

        return View(report);
    }
}

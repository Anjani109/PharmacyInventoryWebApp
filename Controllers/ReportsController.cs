using Microsoft.AspNetCore.Mvc;
using PharmacyInventoryWebApp.Models;

public class ReportsController : Controller
{
    private readonly PharmacyContext _context;

    public ReportsController(PharmacyContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var medicines = _context.Medicines.ToList();

        var model = new ReportsViewModel
        {
            TotalMedicines = medicines.Count,
            ActiveMedicines = medicines.Count(m => m.IsActive),
            InactiveMedicines = medicines.Count(m => !m.IsActive),

            Categories = medicines
                .GroupBy(m => m.Category)
                .Select(g => new CategoryReport
                {
                    Category = g.Key,
                    Count = g.Count()
                })
                .ToList()
        };

        return View(model);
    }
}

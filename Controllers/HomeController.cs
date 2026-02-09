using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyInventoryWebApp.Models;
using System.Diagnostics;

namespace PharmacyInventoryWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly PharmacyContext _context;

        public HomeController(PharmacyContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.TotalMedicines = await _context.Medicines.CountAsync();
            ViewBag.LowStockCount = await _context.Medicines
                .Where(m => m.Quantity < 6)
                .CountAsync();

            ViewBag.ActiveSuppliers = await _context.Suppliers
                .Where(s => s.IsActive)
                .CountAsync();

            var lowStockMedicines = await _context.Medicines
                .Where(m => m.Quantity < 6)
                .OrderBy(m => m.Quantity)
                .Take(5)
                .ToListAsync();

            return View(lowStockMedicines);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}

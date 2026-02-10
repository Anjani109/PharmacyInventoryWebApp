using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyInventoryWebApp.Models;

namespace PharmacyInventoryWebApp.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class SuppliersController : Controller
    {
        private readonly PharmacyContext _context;

        public SuppliersController(PharmacyContext context)
        {
            _context = context;
        }

        // GET: Suppliers
        // GET: Suppliers
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;

            var suppliers = _context.Suppliers.AsQueryable();

            // 🔍 SEARCH
            if (!string.IsNullOrEmpty(searchString))
            {
                suppliers = suppliers.Where(s =>
                    s.SupplierName.Contains(searchString) ||
                    s.ContactPerson.Contains(searchString) ||
                    s.Email.Contains(searchString));
            }

            // 🔃 SORT
            // 🔃 SORT (Active first + Name sort)
            suppliers = sortOrder switch
            {
                "name_desc" => suppliers
                                .OrderByDescending(s => s.IsActive)
                                .ThenByDescending(s => s.SupplierName),

                "date_asc" => suppliers
                                .OrderByDescending(s => s.IsActive)
                                .ThenBy(s => s.CreatedDate),

                "date_desc" => suppliers
                                .OrderByDescending(s => s.IsActive)
                                .ThenByDescending(s => s.CreatedDate),

                _ => suppliers
                        .OrderByDescending(s => s.IsActive)   
                        .ThenBy(s => s.SupplierName)           
            };


            return View(await suppliers.ToListAsync());
        }


        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.SupplierId == id);

            if (supplier == null) return NotFound();

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return NotFound();

            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Supplier supplier)
        {
            if (id != supplier.SupplierId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.SupplierId == id);

            if (supplier == null) return NotFound();

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

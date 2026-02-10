using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyInventoryWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace PharmacyInventoryWebApp.Controllers
{
    [Authorize(Roles = "Admin,Pharmacist")]

    public class MedicinesController : Controller
    {
        private readonly PharmacyContext _context;


        public MedicinesController(PharmacyContext context)
        {
            _context = context;
        }

        // GET: Medicines
        public async Task<IActionResult> Index(string searchString, string sortOrder, int page = 1)

        {
            ViewBag.SortOrder = sortOrder;
            var medicines = _context.Medicines.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                medicines = medicines.Where(m =>
                    m.MedicineName.Contains(searchString) ||
                    m.CompanyName.Contains(searchString) ||
                    m.Category.Contains(searchString));
            }

            medicines = sortOrder switch
            {
                "name_desc" => medicines.OrderByDescending(m => m.MedicineName),
                "price_asc" => medicines.OrderBy(m => m.UnitPrice),
                "price_desc" => medicines.OrderByDescending(m => m.UnitPrice),
                _ => medicines.OrderBy(m => m.MedicineName),
            };
            int pageSize = 10;

            int totalMedicines = await medicines.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalMedicines / pageSize);

            medicines = medicines
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sortOrder;


            return View(await medicines.ToListAsync());
        }


        // GET: Medicines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var medicine = await _context.Medicines
                .FirstOrDefaultAsync(m => m.MedicineId == id);

            if (medicine == null)
                return NotFound();

            return View(medicine);
        }

        // GET: Medicines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicines/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return View(medicine);   // show validation errors
            }

            medicine.CreatedDate = DateTime.Now;

            _context.Medicines.Add(medicine);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: Medicines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null)
                return NotFound();

            return View(medicine);
        }

        // POST: Medicines/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Medicine medicine)
        {
            if (id != medicine.MedicineId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineExists(medicine.MedicineId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medicine);
        }

        // GET: Medicines/Delete/5
        // GET: Medicines/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var medicine = await _context.Medicines
                .FirstOrDefaultAsync(m => m.MedicineId == id);

            if (medicine == null)
                return NotFound();

            return View(medicine);
        }


        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine != null)
            {
                _context.Medicines.Remove(medicine);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }



        private bool MedicineExists(int id)
        {
            return _context.Medicines.Any(e => e.MedicineId == id);
        }
    }
}

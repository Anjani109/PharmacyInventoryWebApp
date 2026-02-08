using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyInventoryWebApp.Models;

namespace PharmacyInventoryWebApp.Controllers
{
    public class MedicinesController : Controller
    {
        private readonly PharmacyContext _context;

        public MedicinesController(PharmacyContext context)
        {
            _context = context;
        }

        // GET: Medicines
        public async Task<IActionResult> Index()
        {
            var medicines = await _context.Medicines.ToListAsync();
            return View(medicines);
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
            if (ModelState.IsValid)
            {
                
           
            return View(medicine);
            }
            medicine.CreatedDate = DateTime.Now;
            _context.Medicines.Add(medicine);
            _context.SaveChanges();
            return RedirectToAction("Index");

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

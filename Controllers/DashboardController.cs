using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PharmacyInventoryWebApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("AdminDashboard");

            if (User.IsInRole("Pharmacist"))
                return RedirectToAction("PharmacistDashboard");

            return RedirectToAction("AccessDenied", "Account");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminDashboard()
        {
            return View();
        }

        [Authorize(Roles = "Pharmacist")]
        public IActionResult PharmacistDashboard()
        {
            return View();
        }
    }
}

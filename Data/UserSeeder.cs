using Microsoft.AspNetCore.Identity;

namespace PharmacyInventoryWebApp.Data
{
    public static class UserSeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            // =========================
            // Admin User
            // =========================
            string adminEmail = "admin@pharmacy.com";
            string adminPassword = "Admin@123";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminUser, adminPassword);
            }

            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // =========================
            // Pharmacist User
            // =========================
            string pharmacistEmail = "pharmacist@pharmacy.com";
            string pharmacistPassword = "Pharma@123";

            var pharmacistUser = await userManager.FindByEmailAsync(pharmacistEmail);

            if (pharmacistUser == null)
            {
                pharmacistUser = new IdentityUser
                {
                    UserName = pharmacistEmail,
                    Email = pharmacistEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(pharmacistUser, pharmacistPassword);
            }

            if (!await userManager.IsInRoleAsync(pharmacistUser, "Pharmacist"))
            {
                await userManager.AddToRoleAsync(pharmacistUser, "Pharmacist");
            }
        }
    }
}

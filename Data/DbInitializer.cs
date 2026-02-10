using Microsoft.AspNetCore.Identity;

namespace PharmacyInventoryWebApp.Data
{

    public static class DbInitializer
    {
        public static async Task SeedRolesAndUsers(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Roles
            string[] roles = { "Admin", "Pharmacist" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Admin user
            if (await userManager.FindByEmailAsync("admin@pharmacy.com") == null)
            {
                var admin = new IdentityUser
                {
                    UserName = "admin@pharmacy.com",
                    Email = "admin@pharmacy.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            // Pharmacist user
            if (await userManager.FindByEmailAsync("pharmacist@pharmacy.com") == null)
            {
                var pharmacist = new IdentityUser
                {
                    UserName = "pharmacist@pharmacy.com",
                    Email = "pharmacist@pharmacy.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(pharmacist, "Pharma@123");
                await userManager.AddToRoleAsync(pharmacist, "Pharmacist");
            }
        }
    }
}


using Microsoft.AspNetCore.Identity;

namespace PharmacyInventoryWebApp.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndUsers(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // 1️⃣ Create Roles
            string[] roles = { "Admin", "Pharmacist" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // 2️⃣ Admin user
            var adminEmail = "admin@pharmacy.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminUser, "Admin@123");
            }

            // 🔥 THIS LINE FIXES ACCESS DENIED
            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // 3️⃣ Pharmacist user
            var pharmacistEmail = "pharmacist@pharmacy.com";
            var pharmacistUser = await userManager.FindByEmailAsync(pharmacistEmail);

            if (pharmacistUser == null)
            {
                pharmacistUser = new IdentityUser
                {
                    UserName = pharmacistEmail,
                    Email = pharmacistEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(pharmacistUser, "Pharma@123");
            }

            if (!await userManager.IsInRoleAsync(pharmacistUser, "Pharmacist"))
            {
                await userManager.AddToRoleAsync(pharmacistUser, "Pharmacist");
            }
        }
    }
}


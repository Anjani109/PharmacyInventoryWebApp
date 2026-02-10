using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace PharmacyInventoryWebApp.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // 1️⃣ Roles create karna
            string[] roles = new string[] { "Admin", "Pharmacist", "Manager" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // 2️⃣ Admin user create karna
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

                var result = await userManager.CreateAsync(adminUser, "Admin@123"); // strong password
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
            // 3️⃣ Create Pharmacist User
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

                var result = await userManager.CreateAsync(pharmacistUser, "Pharma@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(pharmacistUser, "Pharmacist");
                }
            }


        }
    }
}

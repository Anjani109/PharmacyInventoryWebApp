using Microsoft.AspNetCore.Identity;

namespace PharmacyInventoryWebApp.Data
{
    public static class UserSeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            await EnsureUserWithRole(userManager, "admin@pharmacy.com", "Admin@123", "Admin");
            await EnsureUserWithRole(userManager, "manager@pharmacy.com", "Manager@123", "Manager");
            await EnsureUserWithRole(userManager, "pharmacist@pharmacy.com", "Pharma@123", "Pharmacist");
        }

        private static async Task EnsureUserWithRole(
            UserManager<IdentityUser> userManager,
            string email,
            string password,
            string role)
        {
            var existingUser = await userManager.FindByEmailAsync(email);
            if (existingUser is null)
            {
                existingUser = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var createResult = await userManager.CreateAsync(existingUser, password);
                if (!createResult.Succeeded)
                {
                    return;
                }
            }

            if (!await userManager.IsInRoleAsync(existingUser, role))
            {
                await userManager.AddToRoleAsync(existingUser, role);
            }
        }
    }
}

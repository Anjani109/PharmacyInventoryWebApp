using Microsoft.AspNetCore.Identity;

namespace PharmacyInventoryWebApp.Data
{
    public static class UserSeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider services)
        {


        {
                {
                    EmailConfirmed = true
                };

                {
            }

            if (!await userManager.IsInRoleAsync(existingUser, role))
            {
                await userManager.AddToRoleAsync(existingUser, role);
            }
        }
    }
}


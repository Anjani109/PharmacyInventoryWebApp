using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using PharmacyInventoryWebApp.Data;
using PharmacyInventoryWebApp.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<PharmacyContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<PharmacyContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}"
);

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await RoleSeeder.SeedRolesAsync(services);
    await UserSeeder.SeedUsersAsync(services);
    await DbInitializer.SeedRolesAndUsers(services);
}


app.Run();


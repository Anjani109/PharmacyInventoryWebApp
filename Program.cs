using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PharmacyInventoryWebApp.Models;
using PharmacyInventoryWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// =====================
// Database
// =====================
builder.Services.AddDbContext<PharmacyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// =====================
// Identity
// =====================
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<PharmacyContext>()
    .AddDefaultTokenProviders();

// =====================
// MVC
// =====================
builder.Services.AddControllersWithViews();

var app = builder.Build();

// =====================
// Middleware
// =====================
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

// =====================
// Routes
// =====================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// =====================
// Seed Roles & Users
// =====================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await RoleSeeder.SeedRolesAsync(services);
    await UserSeeder.SeedUsersAsync(services);
}

app.Run();

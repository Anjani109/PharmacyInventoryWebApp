using Microsoft.AspNetCore.Identity;
<<<<<<< HEAD
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Authorization;
=======
>>>>>>> eb2921a97ca0364baac7cef2a908277d4f189db3
using Microsoft.EntityFrameworkCore;
using PharmacyInventoryWebApp.Data;
using PharmacyInventoryWebApp.Models;
using PharmacyInventoryWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// =====================
// Database
// =====================
builder.Services.AddDbContext<PharmacyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

<<<<<<< HEAD
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<PharmacyContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AuthorizeFilter());
});

// Configure login & access denied paths
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";       // Redirect to login page
    options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect if unauthorized
});


var app = builder.Build();




// Configure the HTTP request pipeline.
=======
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
>>>>>>> eb2921a97ca0364baac7cef2a908277d4f189db3
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
<<<<<<< HEAD
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


=======
>>>>>>> eb2921a97ca0364baac7cef2a908277d4f189db3

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// =====================
// Routes
// =====================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
<<<<<<< HEAD

using (var scope = app.Services.CreateScope())
{
    await SeedData.InitializeAsync(scope.ServiceProvider);
    await DbInitializer.SeedRolesAndUsers(scope.ServiceProvider);
}

=======
>>>>>>> eb2921a97ca0364baac7cef2a908277d4f189db3

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

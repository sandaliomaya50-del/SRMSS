using Microsoft.EntityFrameworkCore;
using SRMSS.Data;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// DATABASE CONNECTION
// ==========================================

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));


// ==========================================
// SESSION
// ==========================================

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// ==========================================
// MVC
// ==========================================

builder.Services.AddControllersWithViews();


var app = builder.Build();


// ==========================================
// HTTP PIPELINE
// ==========================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


// ==========================================
// ENABLE SESSION
// ==========================================

app.UseSession();


// ==========================================
// AUTHORIZATION
// ==========================================

app.UseAuthorization();


// ==========================================
// DEFAULT ROUTE
// ==========================================

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();

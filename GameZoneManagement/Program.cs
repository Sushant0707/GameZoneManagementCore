using GameZoneManagement.Models;
using GameZoneManagement.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Add MVC
builder.Services.AddControllersWithViews();

// 2️⃣ Add EF Core DbContext
builder.Services.AddDbContext<GameZoneContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// 3️⃣ Register your custom service with Dependency Injection
builder.Services.AddScoped<IUserService, UserService>();

// 4️⃣ Register Session Services (✅ MISSING in your code)
builder.Services.AddDistributedMemoryCache(); // Required for session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Optional timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// 🔁 Add middleware in correct order
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // ✅ Must be added AFTER UseRouting but BEFORE UseAuthorization
app.UseAuthorization();

// ✅ Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=GameZone}/{action=Index}/{id?}");

app.Run();

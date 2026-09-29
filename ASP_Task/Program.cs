using ASP_Task.Data;
using ASP_Task.Models;
using ASP_Task.Repositories;
using ASP_Task.Repositories.Base;
using ASP_Task.Services;
using ASP_Task.Services.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. إضافة الخدمات للـ Container
builder.Services.AddControllersWithViews();

// تسجيل خدمة HttpContextAccessor لدعم _Layout.cshtml والجلسات
builder.Services.AddHttpContextAccessor();

// إضافة الـ Session لدعم حالة تسجيل الدخول
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// إعداد اتصال قاعدة البيانات
var connectionString = builder.Configuration.GetConnectionString("DefaultDatabase");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// تسجيل المستودعات المتوفرة فقط
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// 2. بناء التطبيق
var builderApp = builder.Build();

// 3. إنشاء/تحديث قاعدة البيانات وإضافة البيانات الافتراضية
using (var scope = builderApp.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // مسح القاعدة القديمة وبناؤها من جديد لتجنب أي أخطاء أو أعمدة تالفة
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    // إضافة أدوار افتراضية
    if (!context.Roles.Any())
    {
        context.Roles.Add(new Role { RoleName = "Admin" });
        context.Roles.Add(new Role { RoleName = "User" });
        context.SaveChanges();
    }

    // إضافة مستخدم الأدمن الافتراضي
    if (!context.Users.Any())
    {
        var adminUser = new User
        {
            Username = "admin",
            FullName = "Administrator",
            Email = "admin@example.com",
            HashPassword = BCrypt.Net.BCrypt.HashPassword("123456")
        };

        context.Users.Add(adminUser);
        context.SaveChanges();
    }
}

// 4. إعداد الـ Pipeline
var app = builderApp;

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

// التوجيه الافتراضي
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Login}/{id?}");

app.Run();
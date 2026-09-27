using Microsoft.AspNetCore.Mvc;
using ASP_Task.Data;

namespace ASP_Task.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDbContext _db;

        public AccountsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Username == username);

            // تحقق بسيط من كلمة المرور (يمكنك دمج BCrypt هنا)
            if (user != null && (password == user.HashPassword || BCrypt.Net.BCrypt.Verify(password, user.HashPassword)))
            {
                // حفظ حالة الدخول بسيطة
                HttpContext.Session?.SetString("Username", user.Username);
                return RedirectToAction("Index", "Products");
            }

            ModelState.AddModelError("", "اسم المستخدم أو كلمة المرور غير صحيحة");
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session?.Clear();
            return RedirectToAction("Login");
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP_Task.Data;
using ASP_Task.Models;

namespace ASP_Task.Controllers
{
    public class RolesController : Controller
    {
        private readonly AppDbContext _context;

        public RolesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            var roles = await _context.Roles.ToListAsync();
            return View(roles);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Role role)
        {
            if (ModelState.IsValid)
            {
                _context.Roles.Add(role);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: Roles/AssignPermissions/5
        public async Task<IActionResult> AssignPermissions(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            // التأكد الإجباري من وجود الصلاحيات الأساسية في قاعدة البيانات أولاً
            if (!await _context.Permissions.AnyAsync())
            {
                _context.Permissions.AddRange(
                    new Permission { Name = "AddUser" },
                    new Permission { Name = "EditUser" },
                    new Permission { Name = "DeleteUser" },
                    new Permission { Name = "ViewUsers" }
                );
                await _context.SaveChangesAsync();
            }

            // جلب معرفات الصلاحيات المسجلة لهذا الدور مسبقاً
            var assignedPermissionIds = await _context.PermissionRoles
                .Where(pr => pr.RolesId == id)
                .Select(pr => pr.PermissionId)
                .ToListAsync();

            // جلب جميع الصلاحيات من قاعدة البيانات
            var dbPermissions = await _context.Permissions.ToListAsync();

            var permissionItems = dbPermissions.Select(p => new PermissionItem
            {
                Name = p.Id.ToString(),
                DisplayName = p.Name switch
                {
                    "AddUser" => "إضافة مستخدم (Add User)",
                    "EditUser" => "تعديل مستخدم (Edit User)",
                    "DeleteUser" => "حذف مستخدم (Delete User)",
                    "ViewUsers" => "عرض المستخدمين (View Users)",
                    _ => p.Name ?? $"Permission #{p.Id}"
                },
                IsSelected = assignedPermissionIds.Contains(p.Id)
            }).ToList();

            var model = new RolePermissionsViewModel
            {
                RoleId = role.Id,
                RoleName = role.RoleName,
                Permissions = permissionItems
            };

            return View(model);
        }

        // POST: Roles/AssignPermissions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignPermissions(RolePermissionsViewModel model)
        {
            var roleExists = await _context.Roles.AnyAsync(r => r.Id == model.RoleId);
            if (!roleExists)
            {
                return NotFound();
            }

            // حذف جميع الصلاحيات القديمة المرتبطة بهذا الدور
            var existingPermissions = _context.PermissionRoles
                .Where(pr => pr.RolesId == model.RoleId);
            _context.PermissionRoles.RemoveRange(existingPermissions);
            await _context.SaveChangesAsync(); // تطبيق الحذف فوراً لتفريغ القديم

            var newPermissionsList = new List<PermissionRoles>();

            if (model.Permissions != null)
            {
                foreach (var item in model.Permissions)
                {
                    if (item.IsSelected && int.TryParse(item.Name, out int permId))
                    {
                        var permissionExists = await _context.Permissions.AnyAsync(p => p.Id == permId);
                        if (permissionExists)
                        {
                            newPermissionsList.Add(new PermissionRoles
                            {
                                RolesId = model.RoleId,
                                PermissionId = permId
                            });
                        }
                    }
                }
            }

            // إضافة الصلاحيات الجديدة فقط إذا وُجدت
            if (newPermissionsList.Any())
            {
                await _context.PermissionRoles.AddRangeAsync(newPermissionsList);
                await _context.SaveChangesAsync();
            }

            TempData["SuccessMessage"] = "تم حفظ الصلاحيات بنجاح";
            return RedirectToAction(nameof(Index));
        }
    }
}
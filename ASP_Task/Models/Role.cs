using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Task.Models
{
    public class Role
    {
        public int Id { get; set; } // أو RoleId حسب التسمية لديك
        public string RoleName { get; set; }

        // إضافة هذا السطر يمنع الـ EF Core من محاولة عمل مابينج لهذه الخاصية الخاطئة
        [NotMapped]
        public object Permissions { get; set; }
    }
}
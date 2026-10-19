using System.ComponentModel.DataAnnotations;

namespace ASP_Task.Domain.Models
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // e.g., "Products.Create", "Orders.Index"

        public ICollection<PermissionRoles>? PermissionRoles { get; set; }
    }
}
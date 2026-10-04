namespace ASP_Task.Domain.Models
{
    public class PermissionRoles
    {
        public int RolesId { get; set; }
        public Role Role { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
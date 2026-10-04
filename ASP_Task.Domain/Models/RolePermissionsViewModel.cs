namespace ASP_Task.Domain.Models
{
    public class PermissionItem
    {
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public bool IsSelected { get; set; }
    }

    public class RolePermissionsViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public List<PermissionItem> Permissions { get; set; } = new List<PermissionItem>();
    }
}
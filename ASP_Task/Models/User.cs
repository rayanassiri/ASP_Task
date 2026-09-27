using System.ComponentModel.DataAnnotations;

namespace ASP_Task.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string HashPassword { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;

        public ICollection<RoleUser>? RoleUsers { get; set; }
    }
}
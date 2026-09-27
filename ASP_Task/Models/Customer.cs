using System.ComponentModel.DataAnnotations;

namespace ASP_Task.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
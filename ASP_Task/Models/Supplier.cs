using System.ComponentModel.DataAnnotations;

namespace ASP_Task.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ContactEmail { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
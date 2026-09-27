using System.ComponentModel.DataAnnotations;

namespace ASP_Task.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [Display(Name = "Category Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string? Description { get; set; }

        // العلاقة مع جدول المنتجات
        public ICollection<Product>? Products { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ASP_Task.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
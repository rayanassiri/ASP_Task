namespace ASP_Task.Dtos
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string Phone { get; set; }
    }

    public class CreateSupplierDto
    {
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string Phone { get; set; }
    }
}
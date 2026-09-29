using ASP_Task.Dtos;
using ASP_Task.Models;

namespace ASP_Task.Services.Base
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        void AddCustomer(CreateCustomerDto customerDto);
    }
}
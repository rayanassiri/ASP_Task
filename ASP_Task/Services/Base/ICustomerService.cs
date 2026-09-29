using ASP_Task.Dtos;
using ASP_Task.Models;

namespace ASP_Task.Services.Base
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(CreateCustomerDto customerDto);
        void UpdateCustomer(int id, CreateCustomerDto customerDto);
        void DeleteCustomer(int id);
    }
}
using ASP_Task.Application.Dtos;
using ASP_Task.Domain.Models;

namespace ASP_Task.Application.Services.Base
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
using ASP_Task.Application.Dtos;
using ASP_Task.Domain.Models;
using ASP_Task.Infrastructure.Repositories.Base;
using ASP_Task.Application.Services.Base;

namespace ASP_Task.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _unitOfWork.CustomerRepo.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return _unitOfWork.CustomerRepo.GetById(id);
        }

        public void AddCustomer(CreateCustomerDto customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                Phone = customerDto.Phone
            };

            _unitOfWork.CustomerRepo.Add(customer);
            _unitOfWork.Save();
        }

        public void UpdateCustomer(int id, CreateCustomerDto customerDto)
        {
            var customer = _unitOfWork.CustomerRepo.GetById(id);
            if (customer != null)
            {
                customer.Name = customerDto.Name;
                customer.Email = customerDto.Email;
                customer.Phone = customerDto.Phone;

                _unitOfWork.CustomerRepo.Update(customer);
                _unitOfWork.Save();
            }
        }

        public void DeleteCustomer(int id)
        {
            _unitOfWork.CustomerRepo.Delete(id);
            _unitOfWork.Save();
        }
    }
}
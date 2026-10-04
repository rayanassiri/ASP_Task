using ASP_Task.Domain.Models;
using ASP_Task.Infrastructure.Repositories.Base;
using ASP_Task.Application.Services.Base;

namespace ASP_Task.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _unitOfWork.CategoryRepo.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _unitOfWork.CategoryRepo.GetById(id);
        }

        public void AddCategory(Category category)
        {
            _unitOfWork.CategoryRepo.Add(category);
            _unitOfWork.Save();
        }

        public void UpdateCategory(Category category)
        {
            _unitOfWork.CategoryRepo.Update(category);
            _unitOfWork.Save();
        }

        public void DeleteCategory(int id)
        {
            _unitOfWork.CategoryRepo.Delete(id);
            _unitOfWork.Save();
        }
    }
}
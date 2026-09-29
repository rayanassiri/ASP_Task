using ASP_Task.Models;
using ASP_Task.Repositories.Base;
using ASP_Task.Services.Base;
namespace ASP_Task.Services
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

        public void AddCategory(Category category)
        {
            _unitOfWork.CategoryRepo.Add(category);
            _unitOfWork.Save();
        }
    }
}
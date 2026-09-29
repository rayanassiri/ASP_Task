using ASP_Task.Models;

namespace ASP_Task.Services.Base
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category category);
    }
}
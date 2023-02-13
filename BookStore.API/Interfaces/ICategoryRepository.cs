using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int id);
        Task<IList<Category>> GetAll();
        Task<Category> Add(Category entity);
        Task<Category> Update(int id, Category entity);
        Task<bool> Delete(int id);
    }
}

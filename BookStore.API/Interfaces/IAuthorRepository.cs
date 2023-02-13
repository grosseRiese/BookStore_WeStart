using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author> GetByIdAsync(int id);
        Task<IList<Author>> GetAll();
        Task<Author> Add(Author entity);
        Task<Author> Update(int id, Author entity);
        Task<bool> Delete(int id);
    }
}

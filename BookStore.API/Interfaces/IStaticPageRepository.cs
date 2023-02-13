using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IStaticPageRepository
    {
        //Task<StaticPage> GetByIdAsync(int id);
        Task<IList<StaticPage>> GetAll(string? PageName);
        Task<StaticPage> Add(StaticPage entity);
        Task<StaticPage> Update(StaticPage entity);
        Task<bool> Delete(int id);
    }
}

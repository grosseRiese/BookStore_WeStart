using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IUserFavsRepository
    {
        Task<List<UserFavs>> GetAll();
        Task<UserFavs> Create(UserFavs entity);
        Task<bool> Delete(int id);
    }
}

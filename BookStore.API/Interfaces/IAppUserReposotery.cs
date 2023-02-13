using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IAppUserRepository
    {
        Task<AppUser> GetAll(string id);
    }
}

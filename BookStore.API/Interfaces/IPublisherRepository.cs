using BookStore.API.DTOs;
using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IPublisherRepository
    {
        Task<Publisher> GetByIdAsync(int id);
        Task<IList<Publisher>> GetAll(string? searchKey);
        Task<Publisher> Add(Publisher entity);
        Task<Publisher> Update(Publisher entity);
        Task<bool> Delete(int id);
    } 
}

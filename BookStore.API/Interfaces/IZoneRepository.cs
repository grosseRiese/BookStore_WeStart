using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IZoneRepository
    {
        Task<Zone> GetByIdAsync(int id);
        Task<IList<Zone>> GetAll();
        Task<Zone> Add(Zone entity);
        Task<Zone> Update(Zone entity);
        Task<bool> Delete(int id);
    }
}

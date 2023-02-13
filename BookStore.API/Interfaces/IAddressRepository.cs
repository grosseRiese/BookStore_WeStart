using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> GetByIdAsync(int id);
        Task<IList<Address>> GetAll();
        Task<Address> Add(Address entity);
        Task<Address> Update(int id, Address entity);
        Task<bool> Delete(int id);
    }
}

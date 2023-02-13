using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface ISalesRepository
    {
        //Task<Sales> GetByIdAsync(int id);
        Task<IList<Sales>> GetAll();
        Task<Sales> Add(Sales entity);
        //Task<Sales> Update(int id, Sales entity);
        Task<bool> Delete(int id);
        Task<List<Sales>> GetSaleByUserId(string appUserId);
        public Task<bool> isSold(int id);
    }
}

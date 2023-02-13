using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IBookRepository _iBookRepository;
        public SalesRepository(BookStoreDbContext dbContext, IBookRepository iBookRepository)
        {
            _dbContext = dbContext;
            _iBookRepository = iBookRepository;
        }
        public async Task<bool> Delete(int id)
        {
            Sales entity = await _dbContext.Sales.FindAsync(id);
            if (entity == null)
                return false;
            else
            {
                _dbContext.Sales.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IList<Sales>> GetAll()
        {
            var listResult = await _dbContext.Sales
                .Include(x => x.Book)
                .Include(x => x.AppUser)
                .ToListAsync();

            return listResult;
        }

        public async Task<Sales> Add(Sales entity)
        {

            var result = await _iBookRepository.GetByIdAsync(entity.BookId);
            if (result != null)
            {
                var saleNew = new Sales()
                {
                    amount = (int)result.Price,
                    BookId = entity.BookId,
                    AppUserId = entity.AppUserId,
                    TotalPrice = entity.amount
                };
                await _dbContext.Sales.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return saleNew;
            }
            else
            {
                return entity;
            }
        }
        public async Task<Sales> Update(int id, Sales entity)
        {
            var result = await _dbContext.Sales.FindAsync(id);

            if (result != null)
            {
                result.amount = entity.amount;
                result.Order_date = entity.Order_date;
                result.TotalPrice = entity.TotalPrice;
                result.Book = entity.Book;

                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<bool> isSold(int id)
        {
            var sale = await _dbContext.Sales.FindAsync(id);
            if (sale == null)
                return false;
            else
            {
                if (sale.IsSold == IsSoldStatus.notOk)
                {
                    sale.IsSold = IsSoldStatus.ok;
                    sale.SoldDate = DateTime.Now;
                    _dbContext.Sales.Update(sale);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

            }
            return true;

        }

        public async Task<List<Sales>> GetSaleByUserId(string appUserId)
        {
            var sales = await _dbContext.Sales
                .Include(x => x.Book)
                .Include(x => x.AppUser)
                .Where(x => x.AppUserId == appUserId)
                .ToListAsync();
            return sales;
        }
    }
}

using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class AddressRepository: IAddressRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public AddressRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Address> Add(Address entity)
        {
            await _dbContext.Address.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return (entity);
        }
        public async Task<bool> Delete(int id)
        {
            Address entity = await _dbContext.Address.FindAsync(id);
            if (entity == null)
                return false;
            else
            {
                _dbContext.Address.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IList<Address>> GetAll()
        {
            var listResult = await _dbContext.Address.Include(x => x.Zone).ToListAsync();

            return listResult;
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            var singleEntity = await _dbContext.Address.FindAsync(id);
            return singleEntity;
        }
        public async Task<Address> Update(int id, Address entity)
        {
            var result = await _dbContext.Address.SingleOrDefaultAsync(x => x.Id == entity.Id);

            if (result == null)
            {
                throw new ArgumentException("Obs! The item NOT Found!");
            }else{

                result.Address1 = entity.Address1;
                result.Address2 = entity.Address2;
                result.PostalCode = entity.PostalCode;

                 _dbContext.Address.Update(result);
                await _dbContext.SaveChangesAsync();

                return result;
            }
            
        }
    }
}

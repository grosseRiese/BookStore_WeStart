using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public ContactUsRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ContactUs> Add(ContactUs entity)
        {
            await _dbContext.ContactUs.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return (entity);
        }
        public async Task<bool> Delete(int id)
        {
            ContactUs entity = await _dbContext.ContactUs.FindAsync(id);
            if (entity == null)
                return false;
            else
            {
                _dbContext.ContactUs.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IList<ContactUs>> GetAll()
        {
            var listResult = await _dbContext.ContactUs.ToListAsync();

            return listResult;
        }

        public async Task<ContactUs> GetByIdAsync(int id)
        {
            var singleEntity = await _dbContext.ContactUs.FindAsync(id);
            return singleEntity;
        }
        public async Task<ContactUs> Update(int id, ContactUs entity)
        {
            var result = await _dbContext.ContactUs.FindAsync(id);

            if (result != null)
            {
                result.Email = entity.Email;
                result.Message = entity.Message;
                result.FullName = entity.FullName;

                _dbContext.ContactUs.Update(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}

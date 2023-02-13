using BookStore.API.Data;
using BookStore.API.Models;
using BookStore.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class UserFavsRepository : IUserFavsRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public UserFavsRepository(BookStoreDbContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task<UserFavs> Create(UserFavs entity)
        {
            await _dbContext.UserFavs.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var favoriteList = _dbContext.UserFavs.Where(x => x.BookId == id).FirstOrDefault();

            if (favoriteList == null)
                return false;
            else
            {
                _dbContext.UserFavs.Remove(favoriteList);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<UserFavs>> GetAll()
        {
            return await _dbContext.UserFavs.ToListAsync();
        }
    }
}

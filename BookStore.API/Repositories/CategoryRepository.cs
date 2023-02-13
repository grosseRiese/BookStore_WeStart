using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public CategoryRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Category> Add(Category entity)
        {
            await _dbContext.Categories.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return (entity);
        }
        public async Task<bool> Delete(int id)
        {
            Category entity = await _dbContext.Categories.FindAsync(id);
            if (entity == null)
                return false;
            else
            {
                _dbContext.Categories.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IList<Category>> GetAll()
        {
            var listResult = await _dbContext.Categories.ToListAsync(); 

            return listResult;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var singleEntity = await _dbContext.Categories.FindAsync(id);
            return singleEntity;
        }

        public async Task<Category> Update(int id, Category entity)
        {
            var result = await _dbContext.Categories.FindAsync(id);
            if (result != null)
            {
                result.Name = entity.Name;
                _dbContext.Categories.Update(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}

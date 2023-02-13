using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public AuthorRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> Add([FromForm] Author entity)
        {
            await _dbContext.Authors.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return (entity);
        }
        public async Task<bool> Delete(int id)
        {
            Author author = await _dbContext.Authors.FindAsync(id);
            if (author == null)
                return false;
            else
            {
                _dbContext.Authors.Remove(author);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IList<Author>> GetAll()
        {
            var listResult = await _dbContext.Authors.ToListAsync(); 

            return listResult;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            var singleEntity = await _dbContext.Authors.FindAsync(id);
            return singleEntity;
        }

        public async Task<Author> Update(int id,Author entity)
        {
            var result = await _dbContext.Authors.SingleOrDefaultAsync(x => x.Id == entity.Id);

            if (result == null)
            {
                throw new ArgumentException("Obs! The item NOT Found!");
            }
            else
            {
                result.Name = entity.Name;

                _dbContext.Authors.Update(result);
                await _dbContext.SaveChangesAsync();

                return result;
            }

        }
    }
}

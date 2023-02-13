using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class TranslatorRepository : ITranslatorRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public TranslatorRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Translator> Add(Translator entity)
        {
            await _dbContext.Translators.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return (entity);
        }

        public async Task<bool> Delete(int id)
        {
            Translator entity = await _dbContext.Translators.FindAsync(id);
            if (entity == null)
                return false;
            else
            {
                _dbContext.Translators.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IList<Translator>> GetAll()
        {
            var listResult = await _dbContext.Translators.ToListAsync(); 
            return listResult;
        }

        public async Task<Translator> GetByIdAsync(int id)
        {
            var singleEntity = await _dbContext.Translators.FindAsync(id);
            return singleEntity;
        }

        public async Task<Translator> Update(Translator entity)
        {
            var result = await _dbContext.Translators
                .SingleOrDefaultAsync(x => x.Id == entity.Id);

            if (result != null)
            {
                result.Name = entity.Name;

                _dbContext.Translators.Update(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}

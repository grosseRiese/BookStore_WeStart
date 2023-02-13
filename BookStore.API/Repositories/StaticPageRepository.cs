using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class StaticPageRepository : IStaticPageRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public StaticPageRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StaticPage> Add(StaticPage entity)
        {
            await _dbContext.StaticPages.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return (entity);
        }
        public async Task<bool> Delete(int id)
        {
            StaticPage entity = await _dbContext.StaticPages.FindAsync(id);
            if (entity == null)
                return false;
            else
            {
                _dbContext.StaticPages.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IList<StaticPage>> GetAll(string? PageName)
        {
            var listResult = await _dbContext.StaticPages
                .Where(x => x.PageName == PageName || string.IsNullOrEmpty(PageName))
                .ToListAsync();
            return listResult;
        }

       
        public async Task<StaticPage> Update(StaticPage entity)
        {
            var result = await _dbContext.StaticPages
                .SingleOrDefaultAsync(x => x.Id == entity.Id);

            if (result != null)
            {
                result.PageName = entity.PageName;
                result.Details = entity.Details;

                _dbContext.StaticPages.Update(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        //public async Task<StaticPage> GetByIdAsync(int id)
        //{
        //    var singleEntity = await _dbContext.StaticPages.FindAsync(id);
        //    return singleEntity;
        //}
    }
}

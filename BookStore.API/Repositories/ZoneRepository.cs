using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public ZoneRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Zone> Add(Zone entity)
        {
            await _dbContext.Zones.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return (entity);
        }
        public async Task<bool> Delete(int id)
        {
            Zone entity = await _dbContext.Zones.FindAsync(id);
            if (entity == null)
                return false;
            else
            {
                _dbContext.Zones.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }
        public async Task<IList<Zone>> GetAll()
        {
            var listResult = await _dbContext.Zones.ToListAsync();
            return listResult;
        }
        public async Task<Zone> GetByIdAsync(int id)
        {
            var singleEntity = await _dbContext.Zones.FindAsync(id);
            return singleEntity;
        }
        public async Task<Zone> Update(Zone entity)
        {
            var result = await _dbContext.Zones
                .SingleOrDefaultAsync(x => x.Id == entity.Id);


            if (result != null)
            {
                result.Name = entity.Name;

                _dbContext.Zones.Update(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}

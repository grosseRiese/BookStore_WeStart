using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {

        private readonly BookStoreDbContext _dbContext;
        private readonly IFileUploadService _fileUploadService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PublisherRepository(
            BookStoreDbContext dbContext, IFileUploadService fileUploadService, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _fileUploadService = fileUploadService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Publisher> Add(Publisher  entity)
        {
            await _dbContext.Publishers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return (entity);
        }

        public async Task<bool> Delete(int id)
        {
            Publisher publisher = await _dbContext.Publishers.FindAsync(id);
            if (publisher == null)
                return false;
            else
            {
                _dbContext.Publishers.Remove(publisher);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IList<Publisher>> GetAll(string? searchKey)
        {
            var listResult = await _dbContext.Publishers
                .Where(x => x.Name.Contains(searchKey)
                || string.IsNullOrEmpty(searchKey)).Select(x => new Publisher()
                {
                   Id = x.Id,
                   Name = x.Name,
                   Logo = x.Logo,
                }).ToListAsync(); 

            return listResult;
        }

        public async Task<Publisher> GetByIdAsync(int id)
        {
            var singleEntity = await _dbContext.Publishers.FindAsync(id);
            return singleEntity;
        }

        public async Task<Publisher> Update(Publisher entity)
        {
            var result = await _dbContext.Publishers.SingleOrDefaultAsync(x => x.Id == entity.Id);

            if (result != null)
            {
                result.Name = entity.Name;
                result.Logo = entity.Logo;

                _dbContext.Publishers.Update(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }



            return null;
        }

    }
}

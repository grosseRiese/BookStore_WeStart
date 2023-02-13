using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class BookSuggestionRepository : IBookSuggestionRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public BookSuggestionRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookSuggestion> Add(BookSuggestion entity)
        {
            await _dbContext.BookSuggestions.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return (entity);
        }
        public async Task<bool> Delete(int id)
        {
            BookSuggestion entity = await _dbContext.BookSuggestions.FindAsync(id);
            if (entity == null)
                return false;
            else
            {
                _dbContext.BookSuggestions.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IList<BookSuggestion>> GetAll()
        {
            var listResult = await _dbContext.BookSuggestions.ToListAsync();

            return listResult;
        }

        public async Task<BookSuggestion> GetByIdAsync(int id)
        {
            var singleEntity = await _dbContext.BookSuggestions.FindAsync(id);
            return singleEntity;
        }
        public async Task<BookSuggestion> Update(int id, BookSuggestion entity)
        {
            var result = await _dbContext.BookSuggestions.FindAsync(id);

            if (result != null)
            {
                result.BookName = entity.BookName;
                result.Email = entity.Email;
                result.PublisherName = entity.PublisherName;
                result.AuthorName = entity.AuthorName;
                result.Notes = entity.Notes;

                _dbContext.BookSuggestions.Update(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<bool> isRead(int id)
        {
            var result = await _dbContext.BookSuggestions.FindAsync(id);
            if (result == null)
                return false;
            else
            {
                if (result.ReadAt == null)
                {
                    result.ReadAt = DateTime.Now;
                    _dbContext.BookSuggestions.Update(result);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return true;

            }

        }
    }
}

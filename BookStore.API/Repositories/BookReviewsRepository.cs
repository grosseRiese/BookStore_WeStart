using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class BookReviewsRepository : IBookReviewsRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public BookReviewsRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<BookReviews> Add(BookReviews entity)
        {
            await _dbContext.BookReviews.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return (entity);
        }
        public async Task<bool> Delete(int id)
        {
            BookReviews entity = await _dbContext.BookReviews.FindAsync(id);
            if (entity == null)
                return false;
            else
            {
                _dbContext.BookReviews.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }
        public async Task<IList<BookReviews>> GetAll()
        {
            var listResult = await _dbContext.BookReviews.ToListAsync(); 

            return listResult;
        }
        public async Task<BookReviews> GetByIdAsync(int id)
        {
            var singleEntity = await _dbContext.BookReviews.FindAsync(id);
            return singleEntity;
        }
        public async Task<int> GetBookRating(int bookId)
        {
            var bookRatings = _dbContext.BookReviews.Where(x => x.BookId == bookId && x.Rate != 0);
            if (bookRatings.Count() != 0)
            {
                var Bookrating = await bookRatings.AverageAsync(bookRate => bookRate.Rate);
                return ((int)Bookrating);
            }
            else
            {
                return 0;
            }

        }
        public async Task<BookReviews> Update(int id,BookReviews entity)
        {
            var result = await _dbContext.BookReviews.SingleOrDefaultAsync(x => x.Id == entity.Id);
            if (result == null)
            {
                return result;
            }
            else
            {
                result.Comment = entity.Comment;
                result.Rate = entity.Rate;

                _dbContext.BookReviews.Update(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
        }

    }
}

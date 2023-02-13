using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IBookReviewsRepository
    {
        //Task<BookReviews> GetByIdAsync(int id);
        Task<IList<BookReviews>> GetAll();
        Task<BookReviews> Add(BookReviews entity);
        Task<BookReviews> Update(int id,BookReviews entity);
        Task<bool> Delete(int id);
        Task<int> GetBookRating(int bookId);
    }
}

using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IBookSuggestionRepository
    {
        //Task<BookSuggestion> GetByIdAsync(int id);
        Task<IList<BookSuggestion>> GetAll();
        Task<BookSuggestion> Add(BookSuggestion entity);
        Task<BookSuggestion> Update(int id, BookSuggestion entity);
        Task<bool> Delete(int id);
        public Task<bool> isRead(int id);
    }
}

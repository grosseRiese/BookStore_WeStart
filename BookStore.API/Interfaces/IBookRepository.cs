using BookStore.API.DTOs;
using BookStore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(int id);
        Task<List<Book>> GetAll(string? searchKey);
        Task<Book> Add([FromForm] Book entity);
        Task<Book> Update(int id,Book entity);
        Task<bool> Delete(int id);
        Task<List<Book>> GetAllByCategory(int categoryId);
    }
}

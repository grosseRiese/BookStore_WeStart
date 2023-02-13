using BookStore.API.Data;
using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Services;
//using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookStore.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IFileUploadService _fileUploadService;
        public BookRepository(BookStoreDbContext dbContext,IFileUploadService fileUploadService)
        {
            _dbContext = dbContext;
            _fileUploadService = fileUploadService;
        }
        public async Task<Book> Add([FromForm]  Book entity)
        {
            await _dbContext.Books.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            Book book = await _dbContext.Books.FindAsync(id);
            if (book == null)
                return false;
            else
            {
                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Book>> GetAll(string? searchKey)
        {

            var listResult = await _dbContext.Books
                .Include(c => c.Category)
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .Include(t => t.Translator)
                .ToListAsync();

            listResult = await _dbContext.Books.
                                Where(x => x.Name.Contains(searchKey)
                                || x.Author.Name.Contains(searchKey)
                                || string.IsNullOrEmpty(searchKey))
                                .ToListAsync();

            return listResult;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var singleBook = await _dbContext.Books
                .Include(c => c.Category)
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .Include(t => t.Translator)
                .ToListAsync();

           var sBook = singleBook.Find(x => x.Id == id);

           return sBook;
        }

        public async Task<Book> Update(int id,Book entity)
        {
            var result = await _dbContext.Books.SingleOrDefaultAsync(x => x.Id == entity.Id);


            if (result == null)
            {
                throw new ArgumentException("Obs! The item NOT Found!");
            }
            else
            {
                result.About = entity.About;
                result.Name= entity.Name;
                result.PublishYear = entity.PublishYear;
                result.PageCount = entity.PageCount;
                result.Price = entity.Price;
                result.Discount = entity.Discount;
                result.Image = entity.Image;

                _dbContext.Books.Update(result);
                await _dbContext.SaveChangesAsync();

                return result;
            }
        }

        public async Task<List<Book>> GetAllByCategory(int categoryId)
        {
            var book = await _dbContext.Books
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();
            return book;
        }
    }
}

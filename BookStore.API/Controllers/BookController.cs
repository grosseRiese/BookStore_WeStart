using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Repositories;
using BookStore.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using static System.Reflection.Metadata.BlobBuilder;
using System.Net;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;
        private readonly IFileUploadService _uploaderService;
        public BookController(IBookRepository repository, IFileUploadService uploaderService)
        {
            _repository = repository;
            _uploaderService = uploaderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? searchKey)
        {
            return Ok(await _repository.GetAll(searchKey));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var books = await _repository.GetByIdAsync(id);
            return Ok(books);

        }


        [HttpGet("Category/{id}")]
        public async Task<IActionResult> GetAllByCategory(int id)
        {
            var books = await _repository.GetAllByCategory(id);
            return Ok(books);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBookDto cBookDto)
        {
            var newBook = cBookDto.Adapt<Book>();
            newBook.Image = await _uploaderService.UploadImageAsync(cBookDto.Image);
            var book = await _repository.Add(newBook);
            return Ok(book);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateBookDto bEntityDto)
        {
            if (!ModelState.IsValid || id != bEntityDto.Id)
            {
                return BadRequest("BadRequest..!");
            }

            var newBook = bEntityDto.Adapt<Book>();

            if (bEntityDto.Image != null)
            {
                newBook.Image = await _uploaderService.UploadImageAsync(bEntityDto.Image);
            }

            //newBook.Image = await _uploaderService.UploadImageAsync(bEntityDto.Image);

            var updatedbook = await _repository.Update(id,newBook);
            return Ok(updatedbook);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _repository.Delete(id);
            return Ok(book);
        }

    }
}

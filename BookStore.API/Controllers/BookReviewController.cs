using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Repositories;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReviewController : ControllerBase
    {
        private readonly IBookReviewsRepository _repository;
        private readonly IMapper _mapper;
        public BookReviewController(IBookReviewsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromForm] CreateBookReviewDto createBookReviewDto)
        //{
        //    var newBookReview = createBookReviewDto.Adapt<BookReviews>();
        //    var bookReview = await _repository.Create(newBookReview);
        //    return Ok(bookReview);

        //}


        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetAll(int bookId)
        {
            var bookReview = await _repository.GetBookRating(bookId);
            return Ok(bookReview);

        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(UpdateBookReviewDto updateBookReviewDto)
        //{
        //    var newBookReview = updateBookReviewDto.Adapt<BookReviews>();
        //    var bookReview = await _repository.Update(newBookReview);
        //    return Ok(bookReview);

        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _repository.Delete(id);
        //    return Ok(result);
        //}
        //[HttpGet]
        //public async Task<List<BookReviews>> GetAll()
        //{
        //    return await _repository.GetAll();
        //}
    }
}

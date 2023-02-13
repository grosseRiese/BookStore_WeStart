using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Repositories;
using BookStore.API.Services;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromForm] CreateAuthorDto createAuthorDto)
        {
            var newAuthor = createAuthorDto.Adapt<Author>();
            var author = await _repository.Add(newAuthor);
            return Ok(author);

        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateAuthorDto updateAuthorDto)
        {
            if (!ModelState.IsValid || id != updateAuthorDto.Id)
            {
                return BadRequest("BadRequest..!");
            }

            var newAuthor = updateAuthorDto.Adapt<Author>();
            var author = await _repository.Update(id,newAuthor);
            return Ok(author);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var author = await _repository.GetAll();
            return Ok(author);

        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.Delete(id);
            return Ok(result);
        }


    }
}

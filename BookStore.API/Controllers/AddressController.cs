using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _Mapper;
        public AddressController(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _Mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateAddressDto createAddressDto)
        {
            var newAddress = createAddressDto.Adapt<Address>();
            var address = await _repository.Add(newAddress);
            return Ok(address);

        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateAddressDto updateAddressDto)
        {
            if (!ModelState.IsValid || id != updateAddressDto.Id)
            {
                return BadRequest("BadRequest..!");
            }

            var newAddress = updateAddressDto.Adapt<Address>();
            var updatedEntity = await _repository.Update(id, newAddress);

            return Ok(updatedEntity);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var address = await _repository.GetAll();
            return Ok(address);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.Delete(id);
            return Ok(result);
        }


    }
}

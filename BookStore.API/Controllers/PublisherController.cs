using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Repositories;
using BookStore.API.Services;
//using BookStore.API.Services;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _repository;
        private readonly IFileUploadService _uploaderService;
        private readonly IMapper _mapper;
        public PublisherController(IPublisherRepository repository,IFileUploadService uploaderService,IMapper mapper)
        {
            _repository = repository;
            _uploaderService = uploaderService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreatePublisherDto createPublisherDto)
        {
            var newPublisher = _mapper.Map<Publisher>(createPublisherDto);
            newPublisher.Logo = await _uploaderService.UploadImageAsync(createPublisherDto.Image);
            return Ok(await _repository.Add(newPublisher));

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdatePublisherDto updatePublisherDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BadRequest..!");
            }

            var newPublisher = updatePublisherDto.Adapt<Publisher>();

            if (updatePublisherDto.Logo != null)
            {
                newPublisher.Logo = await _uploaderService.UploadImageAsync(updatePublisherDto.Logo);
            }

            //newPublisher.Logo = await _uploaderService.UploadImageAsync(updatePublisherDto.Logo);

            var publisher = await _repository.Update(newPublisher);
            return Ok(publisher);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string? serachKey)
        {
            var publishers = await _repository.GetAll(serachKey);
            return Ok(publishers);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.Delete(id);
            return Ok(result);
        }
    }
}

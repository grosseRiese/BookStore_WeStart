using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IJwtTokenGenerator _jwtToken;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AuthenticationController(IJwtTokenGenerator jwtToken,UserManager<AppUser> userManager,IMapper mapper)
        {
            _jwtToken = jwtToken;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var user = await _userManager.FindByNameAsync(request.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.password))
            {
                if (user.IsActive)
                {
                    var token = await _jwtToken.Generate(user);
                    return Ok(new { token = token });
                }
                else
                    return Unauthorized(new { message = "Please contact the supporter!" });
            }
            else
                return Unauthorized(new { message = "Unauthorized" });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequestDto request)
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if (userExists != null)
            {
                return BadRequest("User exists!");
            }

            var identityUser = _mapper.Map<AppUser>(request);

            var result = await _userManager.CreateAsync(identityUser, request.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                return BadRequest(new { Errors = errors });
            }

            await _userManager.AddToRoleAsync(identityUser, "User");

            var token = await _jwtToken.Generate(identityUser);

            return Ok(new { token = token });

        }

        [HttpGet]
        public async Task<IActionResult> GetAllByUserId(string? email)
        {

            var userEmail = HttpContext.User.Claims
           .FirstOrDefault(x => x.Type == ClaimTypes.Name).Value ?? email;
            if (userEmail != null)
            {
                var userId = await _userManager.FindByEmailAsync(userEmail)!;
                var user = await _userManager.FindByIdAsync(userId.Id);
                var userRequest = user;
                return Ok(userRequest);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

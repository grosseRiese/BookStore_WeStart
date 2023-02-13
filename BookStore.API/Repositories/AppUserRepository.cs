using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IAppUserRepository _iAppUserRepository;
        private readonly UserManager<AppUser> _userManager;

        public AppUserRepository(BookStoreDbContext dbContext, IAppUserRepository iAppUserRepository, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _iAppUserRepository = iAppUserRepository;
            _userManager = userManager;

        }
        public async Task<AppUser> GetAll(string id)
        {
            var userExists = await _userManager.FindByIdAsync(id);
            return userExists;
        }
    }
}

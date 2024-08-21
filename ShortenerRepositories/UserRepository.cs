using Microsoft.EntityFrameworkCore;
using ShortenerEntities;
using ShortenerRepositoryContracts;
using System;

namespace ShortenerRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<User> AddUser(User? user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _db.Users.ToListAsync();
        }
        public async Task<User> GetUserByUserName(string? userName)
        {
            return await _db.Users.FirstAsync(x => x.UserName == userName);
        }

        public async Task<User> GetUserByUserNamePassword(string? userName, string? password)
        {
            User user = await GetUserByUserName(userName);
            if (user == null)
                return null;
            if (user.Password != password)
                throw new ArgumentException("password didn't match");
            return user;
        }
    }
}
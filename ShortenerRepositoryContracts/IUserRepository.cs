using ShortenerEntities;
using System;

namespace ShortenerRepositoryContracts
{
    public interface IUserRepository
    {
        Task<User> AddUser(User? user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByUserName(string? userName);
        Task<User> GetUserByUserNamePassword(string? userName, string? password);

    }
}
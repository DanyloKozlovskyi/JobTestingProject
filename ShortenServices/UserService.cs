using Microsoft.Extensions.Logging;
using ShortenerEntities;
using ShortenerRepositoryContracts;
using ShortenerServiceContracts;
using ShortenerServiceContracts.DTO;
using ShortenServices.Helpers;
using System;

namespace ShortenServices
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<UserResponse> AddUser(UserAddRequest? userAddRequest)
		{
			if (userAddRequest == null)
				throw new ArgumentNullException(nameof(userAddRequest));

			// Model validation
			ValidationHelper.ModelValidation(userAddRequest);

			if (userAddRequest.PersonName == null)
				throw new ArgumentException(nameof(userAddRequest.PersonName));

			// convert object from PersonAddRequest to Person type
			User user = userAddRequest.ToUser();

			// generate PersonId
			user.UserId = Guid.NewGuid();

			// Add person into _people
			await _userRepository.AddUser(user);

			// return object from Person to PersonResponse type
			return user.ToUserResponse();
		}

		public async Task<List<UserResponse>> GetAllUsers()
		{
			List<UserResponse> persons = (await _userRepository.GetAllUsers()).Select(temp => temp.ToUserResponse()).ToList();
			return persons;
		}
		public async Task<UserResponse?> GetUserByUserName(string? userName)
		{
			if (string.IsNullOrEmpty(userName))
				return null;

			User? user = await _userRepository.GetUserByUserName(userName);

			if (user == null)
				return null;

			return user.ToUserResponse();
		}

		public async Task<UserResponse?> GetUserByUserNamePassword(string? userName, string? password)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
				return null;

			User? user = await _userRepository.GetUserByUserNamePassword(userName, password);

			if (user == null)
				return null;

			return user.ToUserResponse();
		}
	}
}
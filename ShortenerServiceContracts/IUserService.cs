using ShortenerEntities;
using ShortenerServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenerServiceContracts
{
	public interface IUserService
	{
		Task<UserResponse> AddUser(UserAddRequest? userAddRequest);
		Task<List<UserResponse>> GetAllUsers();
		Task<UserResponse?> GetUserByUserName(string? userName);
		Task<UserResponse?> GetUserByUserNamePassword(string? userName, string? password);

	}
}

using ShortenerEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShortenerServiceContracts.DTO
{
	public class UserResponse
	{
		public Guid? UserId { get; set; }
		public string? UserName { get; set; }
		public string? Password { get; set; }

		public override bool Equals(object? obj)
		{
			if (obj is UserResponse userResponse)
			{
				return UserId == userResponse.UserId &&
					UserName == userResponse.UserName &&
					Password == userResponse.Password;
			}
			return false;
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		public override string ToString()
		{
			return $"Person object - PersonId: {UserId}, PersonName: {UserName}, " +
				$"Password: {Password}";
		}
		public User ToUser()
		{
			return new User()
			{
				UserId = this.UserId,
				UserName = this.UserName,
				Password = this.Password,
			};
		}

	}
	public static class UserExtensions
	{
		public static UserResponse ToUserResponse(this User user)
		{
			return new UserResponse()
			{
				UserId = user.UserId,
				UserName = user.UserName,
				Password = user.Password,
			};
		}
	}
}

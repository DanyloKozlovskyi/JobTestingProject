using ShortenerEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenerServiceContracts.DTO
{
	public class UserAddRequest
	{
		[Required(ErrorMessage = "Person Name can't be blank")]
		public string? PersonName { get; set; }
		[Required(ErrorMessage = "Password can't be blank")]
		public string? Password { get; set; }
		public bool IsGuest { get; set; } = false;
	}
	public static class UserAddRequestExtensions
	{
		public static User ToUser(this UserAddRequest userAddRequest)
		{
			return new User()
			{
				UserName = userAddRequest.PersonName,
				Password = userAddRequest.Password,
			};
		}
	}
}

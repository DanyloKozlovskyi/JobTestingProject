using Microsoft.AspNetCore.Mvc;
using ShortenerEntities;
using ShortenerServiceContracts;
using ShortenerServiceContracts.DTO;

namespace ShortenerExample.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}
		[Route("[action]")]
		public IActionResult Index()
		{
			return View();
		}
		[Route("[action]")]
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[Route("[action]")]
		[HttpPost]
		public async Task<IActionResult> Login(UserAddRequest userAddRequest)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
				return View("Login");
			}
			try
			{
				if (await _userService.GetUserByUserNamePassword(userAddRequest.PersonName, userAddRequest.Password) == null)
				{
					return View("Login");
				}
			}
			catch (Exception ex)
			{
				if (ViewBag.Errors != null)
				{
					ViewBag.Errors.Add(ex.Message);
				}
				else
				{
					ViewBag.Errors = new List<string>() { ex.Message };
				}
				return View("Login");
			}

			UserResponse? user = await _userService.GetUserByUserNamePassword(userAddRequest.PersonName, userAddRequest.Password);

			User? u = user.ToUser();
			return RedirectToAction("Index", "ShortenedUrl", u);
		}
	}
}

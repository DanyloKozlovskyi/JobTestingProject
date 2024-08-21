using Microsoft.EntityFrameworkCore;
using ShortenerEntities;
using ShortenerRepositories;
using ShortenerRepositoryContracts;
using ShortenerServiceContracts;
using ShortenServices;

namespace ShortenerExample
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();

			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<IShortenedUrlService, ShortenedUrlService>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IShortenedUrlRepository, ShortenedUrlRepository>();
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			var app = builder.Build();

			app.UseRouting();
			app.UseStaticFiles();
			app.MapControllers();
			app.UseHttpLogging();

			app.Run();
		}
	}
}
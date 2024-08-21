using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenerEntities
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ShortenedUrl> ShortenedUrls { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<ShortenedUrl>().ToTable("ShortenedUrls");

            modelBuilder.Entity<User>()
              .HasIndex(temp => temp.UserName).IsUnique();

            // Seed to Countries
            string usersJson = File.ReadAllText("users.json");
            List<User> users = System.Text.Json.JsonSerializer.Deserialize<List<User>>(usersJson);

            foreach (User user in users)
            {
                modelBuilder.Entity<User>().HasData(user);
            }

            //add ShortenedUrls

            //Table Relations
            /*modelBuilder.Entity<ShortenedUrl>(entity =>
			{
                entity.HasOne<User>(s => s.Person)
                .WithMany(u => u.Urls)
                .HasForeignKey(s => s.UserId);
            });*/
        }
    }
}

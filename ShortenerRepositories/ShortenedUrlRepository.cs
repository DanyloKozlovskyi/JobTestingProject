using Microsoft.EntityFrameworkCore;
using ShortenerEntities;
using ShortenerRepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenerRepositories
{
    public class ShortenedUrlRepository : IShortenedUrlRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly Random _random = new Random();
        public ShortenedUrlRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ShortenedUrl> AddUrl(ShortenedUrl? url)
        {
            await _db.ShortenedUrls.AddAsync(url);
            await _db.SaveChangesAsync();
            return url;
        }

        public async Task<List<ShortenedUrl>> GetAllUrls()
        {
            return await _db.ShortenedUrls.Include("User").ToListAsync();
        }
        public async Task<ShortenedUrl?> GetUrlByUrlId(Guid? urlId)
        {
            return await _db.ShortenedUrls.Include("User").FirstAsync(x => x.Id == urlId);
        }
        public async Task<bool> DeleteUrl(Guid? urlId)
        {
            if (urlId == null)
            {
                throw new ArgumentNullException(nameof(urlId));
            }

            ShortenedUrl? url = await _db.ShortenedUrls.FirstOrDefaultAsync(temp => temp.Id == urlId);
            if (url == null)
                return false;

            _db.ShortenedUrls.Remove(await _db.ShortenedUrls.FirstAsync(temp => temp.Id == urlId));
            await _db.SaveChangesAsync();

            return true;
        }
        public async Task<string> GenerateUniqueCode()
        {
            var codeChars = new char[ShortLinkSettings.Length];
            int maxValue = ShortLinkSettings.Alphabet.Length;

            while (true)
            {
                for (var i = 0; i < ShortLinkSettings.Length; i++)
                {
                    var randomIndex = _random.Next(maxValue);

                    codeChars[i] = ShortLinkSettings.Alphabet[randomIndex];
                }
                var code = new string(codeChars);

                if (!await _db.ShortenedUrls.AnyAsync(s => s.Code == code))
                {
                    return code;
                }
            }
        }
    }
}

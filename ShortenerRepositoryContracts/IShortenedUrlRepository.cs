using ShortenerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenerRepositoryContracts
{
    public interface IShortenedUrlRepository
    {
        Task<ShortenedUrl> AddUrl(ShortenedUrl? url);
        Task<List<ShortenedUrl>> GetAllUrls();
        Task<ShortenedUrl?> GetUrlByUrlId(Guid? urlId);
        Task<bool> DeleteUrl(Guid? urlId);
        Task<string> GenerateUniqueCode();
    }
}

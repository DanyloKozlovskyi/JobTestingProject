using ShortenerEntities;
using ShortenerServiceContracts.DTO;
using System;

namespace ShortenerServiceContracts
{
    public interface IShortenedUrlService
    {
        Task<ShortenedUrlResponse> AddUrl(ShortenedUrlAddRequest? urlAddRequest);
        Task<List<ShortenedUrlResponse>> GetAllUrls();
        Task<ShortenedUrlResponse?> GetUrlByUrlId(Guid? urlId);
        Task<bool> DeleteUrl(Guid? urlId);
        Task<string> GenerateUniqueCode();
    }
}
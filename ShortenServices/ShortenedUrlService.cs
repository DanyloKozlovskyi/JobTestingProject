using Microsoft.EntityFrameworkCore;
using ShortenerEntities;
using ShortenerRepositoryContracts;
using ShortenerServiceContracts;
using ShortenerServiceContracts.DTO;
using ShortenServices.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenServices
{
    public class ShortenedUrlService : IShortenedUrlService
    {
        private readonly IShortenedUrlRepository _urlRepository;
        public ShortenedUrlService(IShortenedUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<ShortenedUrlResponse> AddUrl(ShortenedUrlAddRequest? urlAddRequest)
        {
            if (urlAddRequest == null)
                throw new ArgumentNullException(nameof(urlAddRequest));

            // Model validation
            ValidationHelper.ModelValidation(urlAddRequest);

            if (urlAddRequest.LongUrl == null)
                throw new ArgumentException(nameof(urlAddRequest.LongUrl));

            // convert object from PersonAddRequest to Person type
            ShortenedUrl url = urlAddRequest.ToShortenedUrl();

            // generate PersonId
            url.Id = Guid.NewGuid();

            // Add person into _people
            await _urlRepository.AddUrl(url);

            // return object from Person to PersonResponse type
            return url.ToShortenedUrlResponse();
        }

        public async Task<List<ShortenedUrlResponse>> GetAllUrls()
        {
            List<ShortenedUrlResponse> urls = (await _urlRepository.GetAllUrls()).Select(temp => temp.ToShortenedUrlResponse()).ToList();
            return urls;
        }

        public async Task<bool> DeleteUrl(Guid? urlId)
        {
            if (urlId == null)
            {
                throw new ArgumentNullException(nameof(urlId));
            }

            ShortenedUrl? url = await _urlRepository.GetUrlByUrlId(urlId);
            if (url == null)
                return false;

            await _urlRepository.DeleteUrl(urlId);

            return true;
        }

        public async Task<ShortenedUrlResponse?> GetUrlByUrlId(Guid? urlId)
        {
            if (urlId == null)
                return null;

            ShortenedUrl? url = await _urlRepository.GetUrlByUrlId(urlId);

            if (url == null)
                return null;

            return url.ToShortenedUrlResponse();
        }
        public async Task<string> GenerateUniqueCode()
        {
            return await _urlRepository.GenerateUniqueCode();
        }



    }
}

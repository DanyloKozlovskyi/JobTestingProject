using ShortenerEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenerServiceContracts.DTO
{
    public class ShortenedUrlAddRequest
    {
        [Required(ErrorMessage = "Url can't be blank")]
        public string? LongUrl { get; set; } = string.Empty;
        public string? ShortUrl { get; set; } = string.Empty;

        public string? Code { get; set; } = string.Empty;

        public Guid? UserId { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public User? User { get; set; }
    }
    public static class ShortenedUrlAddRequestExtensions
    {
        public static ShortenedUrl ToShortenedUrl(this ShortenedUrlAddRequest urlAddRequest)
        {
            return new ShortenedUrl()
            {
                LongUrl = urlAddRequest.LongUrl,
                ShortUrl = urlAddRequest.ShortUrl,
                Code = urlAddRequest.Code,
                UserId = urlAddRequest.UserId,
                CreatedOnUtc = urlAddRequest.CreatedOnUtc,
                User = urlAddRequest.User
            };
        }

    }
}

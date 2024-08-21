using ShortenerEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenerServiceContracts.DTO
{
    public class ShortenedUrlResponse
    {
        public Guid? Id { get; set; }

        public string? LongUrl { get; set; } = string.Empty;

        public string? ShortUrl { get; set; } = string.Empty;

        public string? Code { get; set; } = string.Empty;

        public Guid? UserId { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public User? User { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is ShortenedUrlResponse urlResponse)
            {
                return LongUrl == urlResponse.LongUrl;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"Url object - LongUrl: {LongUrl}, ShortUrl: {ShortUrl}, Created: {CreatedOnUtc.ToShortDateString()}";
        }
        public ShortenedUrlUpdateRequest ToShortenedUrlUpdateRequest()
        {
            return new ShortenedUrlUpdateRequest()
            {
                Id = this.Id,
                LongUrl = this.LongUrl,
                ShortUrl = this.ShortUrl,
                Code = this.Code,
                UserId = this.UserId,
                CreatedOnUtc = this.CreatedOnUtc,
                User = this.User
            };
        }
    }
    public static class ShortenedUrlExtensions
    {
        public static ShortenedUrlResponse ToShortenedUrlResponse(this ShortenedUrl url)
        {
            return new ShortenedUrlResponse()
            {
                Id = url.Id,
                LongUrl = url.LongUrl,
                ShortUrl = url.ShortUrl,
                Code = url.Code,
                CreatedOnUtc = url.CreatedOnUtc,
                UserId = url.UserId,
                User = url.User,
            };
        }
    }
}

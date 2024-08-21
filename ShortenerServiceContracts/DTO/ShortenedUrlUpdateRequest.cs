using ShortenerEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenerServiceContracts.DTO
{
    public class ShortenedUrlUpdateRequest
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "Url can't be blank")]
        public string? LongUrl { get; set; } = string.Empty;
        public string? ShortUrl { get; set; } = string.Empty;

        public string? Code { get; set; } = string.Empty;

        public Guid? UserId { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public User? User { get; set; }

        public ShortenedUrl ToShortenedUrl()
        {
            return new ShortenedUrl()
            {
                Id = this.Id,
                LongUrl = this.LongUrl,
                ShortUrl = this.ShortUrl,
                Code = this.Code,
                UserId = this.UserId,
                CreatedOnUtc = this.CreatedOnUtc,
                User = this.User,
            };
        }
    }

}

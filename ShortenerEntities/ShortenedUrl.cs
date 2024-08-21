using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenerEntities
{
    public class ShortenedUrl
    {
        [Key]
        public Guid? Id { get; set; }
        [StringLength(40)]
        public string? LongUrl { get; set; } = string.Empty;
        [StringLength(40)]
        public string? ShortUrl { get; set; } = string.Empty;

        public string? Code { get; set; } = string.Empty;

        public Guid? UserId { get; set; }

        public DateTime CreatedOnUtc { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}

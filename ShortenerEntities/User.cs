using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShortenerEntities
{
    public class User
    {
        [Key]
        public Guid? UserId { get; set; }
        [StringLength(40)]
        public string? UserName { get; set; }
        [StringLength(40)]
        public string? Password { get; set; }

        /*public virtual ICollection<ShortenedUrl>? Urls { get; set; }*/
    }
}
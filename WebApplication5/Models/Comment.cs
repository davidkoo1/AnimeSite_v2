using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    [PrimaryKey("AnimeName", "UserId", "SeasonNumber", "EpisodeNumber")]
    public class Comment
    {
        
        public string AnimeName { get; set; }
        
        public int SeasonNumber { get; set; }
        
        public int EpisodeNumber { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public string Message { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;

        [ForeignKey("AnimeName, SeasonNumber, EpisodeNumber")]
        public virtual Episode Episode { get; set; }

        public virtual User User { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [PrimaryKey("AnimeName", "SeasonNumber", "AppUserId")]
    public class Rating
    {
        public string AnimeName { get; set; }
        public int SeasonNumber { get; set; }

        [ForeignKey("User")]
        public string? AppUserId { get; set; }

        public int Mark { get; set; }

        [ForeignKey("AnimeName, SeasonNumber")]
        public virtual Season Season { get; set; }
        public virtual User User { get; set; }
    }
}

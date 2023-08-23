using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    [PrimaryKey("AnimeName", "AppUserId")]
    public class FavouriteAnime
    {
        [ForeignKey("Anime"), Column(Order = 0)]
        public string AnimeName { get; set; }

        [ForeignKey("User"), Column(Order = 1)]
        public string? AppUserId { get; set; }

        public DateTime? dateTime { get; set; } = DateTime.Now;
        public virtual Anime? Anime { get; set; }
        public virtual User? User { get; set; }
    }

}

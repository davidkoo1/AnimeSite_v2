using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [PrimaryKey("AnimeName", "AppUserId")]
    public class FavouriteAnime
    {
        [ForeignKey("Anime"), Column(Order = 0)]
        public string AnimeName { get; set; }

        [ForeignKey("User"), Column(Order = 1)]
        public string? AppUserId { get; set; }

        public DateTime? dateTime { get; set; }
        public virtual Anime? Anime { get; set; }
        public virtual User? User { get; set; }
    }

}

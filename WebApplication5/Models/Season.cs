using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    [PrimaryKey("AnimeName", "SeasonNumber")]
    public class Season
    {
        public string AnimeName { get; set; }
        public int SeasonNumber { get; set; }
        public string SeasonTitle { get; set; }
        public string SeasonImage { get; set; }

        [ForeignKey("AnimeName")]
        public virtual Anime? Anime { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; }
        public virtual ICollection<Rating>? Ratings { get; set; }
    }
}

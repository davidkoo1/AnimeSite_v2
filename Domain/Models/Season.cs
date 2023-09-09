using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
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
        public virtual List<Episode> Episodes { get; set; }
        public virtual IList<Rating>? Ratings { get; set; }
    }
}

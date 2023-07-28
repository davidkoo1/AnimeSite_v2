using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Season
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string TitleImage { get; set; }
        [ForeignKey("Anime")]
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }
        public ICollection<Episode> Episodes { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}

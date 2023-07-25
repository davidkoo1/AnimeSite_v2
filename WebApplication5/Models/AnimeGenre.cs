using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class AnimeGenre
    {

        [ForeignKey("Anime")]
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}

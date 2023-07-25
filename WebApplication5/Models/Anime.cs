using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Anime
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string TitleImage { get; set; }
        public string VideoGuid { get; set; }

        [ForeignKey("Editor")]
        public int EditorId { get; set; }
        public Editor Editor { get; set; }

        public ICollection<Season> Seasons { get; set; }

        public ICollection<AnimeGenre> AnimeGenres { get; set; }
    }
}

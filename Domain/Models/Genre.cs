using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<AnimeGenre>? AnimeGenres { get; set; }
    }
}

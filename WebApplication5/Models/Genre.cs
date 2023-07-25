using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AnimeGenre> AnimeGenres { get; set; }
    }
}

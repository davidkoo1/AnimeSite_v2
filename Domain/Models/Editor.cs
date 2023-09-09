using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Editor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        public virtual IList<Anime>? Animes { get; set; }
    }
}

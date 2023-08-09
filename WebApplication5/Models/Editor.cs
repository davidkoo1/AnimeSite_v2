using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Editor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Anime> Animes { get; set; }
    }
}

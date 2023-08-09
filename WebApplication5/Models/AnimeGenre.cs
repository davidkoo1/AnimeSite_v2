using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    [PrimaryKey("AnimeName", "GenreId")]
    public class AnimeGenre
    {

        
        [ForeignKey("Anime"), Column(Order = 0)]
        public string AnimeName { get; set; }

        [ForeignKey("Genre"), Column(Order = 1)]
        public int GenreId { get; set; }

        public virtual Anime Anime { get; set; }
        public virtual Genre Genre { get; set; }
    }
}

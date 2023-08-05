using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Episode
    {
        [Key]
        public int Id { get; set; }
        public string EpisodeSrc { get; set; }
        [ForeignKey("Season")]
        public int SeasonId { get; set; }
        public Season Season { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}

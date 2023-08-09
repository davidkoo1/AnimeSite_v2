using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    [PrimaryKey("AnimeName", "SeasonNumber", "EpisodeNumber")]
    public class Episode
    {
        public string AnimeName { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeSrc { get; set; }
        public DateTime ReleaseEpisode { get; set; } = DateTime.Now;

        [ForeignKey("AnimeName, SeasonNumber")] // Define the composite foreign key using the navigation properties
        public virtual Season? Season { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }
    }



}

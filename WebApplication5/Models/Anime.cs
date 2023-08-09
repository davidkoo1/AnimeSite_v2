using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Anime
    {        
        [ForeignKey("Editor"), Column(Order = 0)]
        public int EditorId { get; set; }

        [Key, Column(Order = 1)]
        public string AnimeName { get; set; }
        public string? Description { get; set; }
        public string TitleImage { get; set; }
        public string Trailer { get; set; } //Мб вообще стоит удалить, Если руки дайдут, когда будем наводится на аниме, чтоб показывали трейлер


        public virtual Editor Editor { get; set; }
        public virtual ICollection<Season> Seasons { get; set; }
        public virtual ICollection<AnimeGenre> AnimeGenres { get; set; }
        //public virtual ICollection<Genre>? Genres { get; set; }
        //public virtual ICollection<Editor>? Editors { get; set; }
    }
}

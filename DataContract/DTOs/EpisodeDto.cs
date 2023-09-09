namespace DataContract.DTOs
{
    public class EpisodeDto
    {
        public string AnimeName { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeSrc { get; set; }
        public DateTime ReleaseEpisode { get; set; } = DateTime.Now;

        public virtual SeasonDto? Season { get; set; }

        public virtual ICollection<CommentDto>? Comments { get; set; }
    }
}

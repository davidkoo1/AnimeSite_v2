namespace DataContract.DTOs
{
    public class SeasonDto
    {
        public string AnimeName { get; set; }
        public int SeasonNumber { get; set; }
        public string SeasonTitle { get; set; }
        public string SeasonImage { get; set; }

        public virtual AnimeDto? Anime { get; set; }
        public virtual List<EpisodeDto> Episodes { get; set; }
        public virtual ICollection<RatingDto>? Ratings { get; set; }
    }
}

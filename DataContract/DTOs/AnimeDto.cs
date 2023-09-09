namespace DataContract.DTOs
{
    public class AnimeDto
    {
        public int EditorId { get; set; }
        public string AnimeName { get; set; }
        public string? Description { get; set; }
        public string TitleImage { get; set; }
        public string? Trailer { get; set; }
        public virtual EditorDto Editor { get; set; }
        public virtual List<SeasonDto> Seasons { get; set; }
        public virtual List<AnimeGenreDto>? AnimeGenres { get; set; }
        public virtual List<FavouriteAnimeDto>? FavouriteAnime { get; set; }
    }
}

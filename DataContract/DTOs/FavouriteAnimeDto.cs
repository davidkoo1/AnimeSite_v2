namespace DataContract.DTOs
{
    public class FavouriteAnimeDto
    {
        public string AnimeName { get; set; }
        public string? AppUserId { get; set; }
        public DateTime? dateTime { get; set; } = DateTime.Now;

        public virtual AnimeDto? Anime { get; set; }
        public virtual UserDto? User { get; set; }
    }

}

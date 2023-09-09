namespace DataContract.DTOs
{
    public class AnimeGenreDto
    {
        public string AnimeName { get; set; }
        public int GenreId { get; set; }

        public virtual AnimeDto Anime { get; set; }
        public virtual GenreDto Genre { get; set; }
    }
}

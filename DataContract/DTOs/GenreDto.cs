namespace DataContract.DTOs
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AnimeGenreDto>? AnimeGenres { get; set; }

    }
}

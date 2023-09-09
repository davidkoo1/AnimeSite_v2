namespace DataContract.DTOs
{
    public class EditorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        public virtual ICollection<AnimeDto>? Animes { get; set; }
    }
}

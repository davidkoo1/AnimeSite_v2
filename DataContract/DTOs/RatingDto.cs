namespace DataContract.DTOs
{
    public class RatingDto
    {
        public string AnimeName { get; set; }
        public int SeasonNumber { get; set; }
        public string? AppUserId { get; set; }
        public int Mark { get; set; }

        public virtual SeasonDto Season { get; set; }
        public virtual UserDto User { get; set; }
    }
}

namespace DataContract.DTOs
{
    public class CommentDto
    {
        public Guid CommentId { get; set; } = Guid.NewGuid();
        public string AnimeName { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string? AppUserId { get; set; }
        public string Message { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;

        public virtual EpisodeDto Episode { get; set; }
        public virtual UserDto User { get; set; }

    }
}


namespace WebApplication5.Models
{
    public class User 
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string? ProfileImage { get; set; }

        public virtual ICollection<Rating>? Rating { get; set; }
        public virtual ICollection<Comment>? Comment { get; set; }
    }
}

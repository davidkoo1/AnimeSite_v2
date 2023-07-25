using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Episode")]
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }

    }
}

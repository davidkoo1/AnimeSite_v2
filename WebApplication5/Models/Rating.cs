using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int Mark { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Season")]
        public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}

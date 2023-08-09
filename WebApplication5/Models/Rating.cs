using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    [PrimaryKey("AnimeName", "SeasonNumber", "UserId")]
    public class Rating 
    {
        public string AnimeName { get; set; }
        public int SeasonNumber { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public int Mark { get; set; }

        [ForeignKey("AnimeName, SeasonNumber")]
        public virtual Season Season { get; set; }
        public virtual User User { get; set; }
    }
}

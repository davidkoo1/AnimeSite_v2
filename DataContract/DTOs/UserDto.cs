using Microsoft.AspNetCore.Identity;

namespace DataContract.DTOs
{
    public class UserDto : IdentityUser
    {
        public string? ProfileImage { get; set; }
        public virtual ICollection<RatingDto>? Rating { get; set; }
        public virtual ICollection<CommentDto>? Comment { get; set; }
        public virtual List<FavouriteAnimeDto>? FavouriteAnime { get; set; }
    }
}

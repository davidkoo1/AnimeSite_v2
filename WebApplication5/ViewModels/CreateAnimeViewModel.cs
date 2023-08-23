using CloudinaryDotNet.Actions;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication5.Models;

namespace WebApplication5.ViewModels
{
    public class CreateAnimeViewModel
    {
        public int EditorId { get; set; }
        public string AnimeName { get; set; }
        public string? Description { get; set; }
        public IFormFile? TitleImageUpload { get; set; }
        public string? TitleImageLink { get; set; }
        public string? Trailer { get; set; }
        public virtual List<AnimeGenre>? AnimeGenres { get; set; }
        public CreateSeasonViewModel SeasonVM { get; set; }
    }
}

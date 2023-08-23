namespace WebApplication5.ViewModels
{
    public class CreateSeasonViewModel
    {
        public string AnimeName { get; set; }
        public int SeasonNumber { get; set; }
        public string SeasonTitle { get; set; }
        public IFormFile? SeasonImageSrcUpload { get; set; }
        public string? SeasonImageSrcLink { get; set; }
        public CreateEpisodeViewModel EpisodeVM { get; set; }
    }
}

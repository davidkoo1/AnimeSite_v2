namespace WebApplication5.ViewModels
{
    public class CreateEpisodeViewModel
    {
        public string AnimeName { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public IFormFile? EpisodeSrcUpload { get; set; }
        public string? EpisodeSrcLink { get; set; }
    }
}

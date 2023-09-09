using Domain.Models;

namespace WebApplication5.ViewModels
{
    public class ListAnimeByGenreViewModel
    {
        public IList<AnimeGenre> Animes { get; set; }
        public bool NoAnimeWarning { get; set; } = false;
        public string Genre { get; set; }

    }
}

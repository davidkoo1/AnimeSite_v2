using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class AnimeController : Controller
    {
        private readonly DataContext _dataContext;
        public AnimeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {//.Include(e => e.Seasons).ThenInclude(ep => ep.Episodes)
            var animes = _dataContext.Anime
                .Include(a => a.Seasons).ThenInclude(s => s.Ratings)
                .Include(a => a.Editor)
                .Include(a => a.AnimeGenres).ThenInclude(ag => ag.Genre)
                .ToList();

            return View(animes);
        }

        
        public IActionResult Detail(int id)
        {
            Anime anime = _dataContext.Anime.FirstOrDefault(a => a.Id == id);
            return View(anime);
        }
    }
}

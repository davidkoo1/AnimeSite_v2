using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IAnimeRepository _animeRepository;
        public AnimeController(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }
        // localhost/
        public async Task<IActionResult> Index()
        {
            var animes =  await _animeRepository.GetAllAnime();
            /*
            var animes = _dataContext.Anime
                 .Include(a => a.Seasons).ThenInclude(s => s.Ratings)
                 .Include(a => a.Editor)
                 .Include(a => a.AnimeGenres).ThenInclude(ag => ag.Genre)
                 .ToList();*/

            return View(animes);
        }

        // localhost/Anime/{animeName}
        /*public IActionResult Detail(string animeName, string? seasonName)
        {
            Anime anime = _dataContext.Anime.Include(a => a.Seasons).ThenInclude(e => e.Episodes).FirstOrDefault(a => a.Title == animeName);
            if (anime == null)
            {
                return NotFound();
            }
            ViewBag.SelectSeason = seasonName;
            return View(anime);
        }

        // localhost/Anime/{animeName}/season-{seasonId}
        public IActionResult Season(string animeName, int seasonId)
        {
            Season season = _dataContext.Seasons.Include(s => s.Episodes).Include(a => a.Anime).FirstOrDefault(s => s.Id == seasonId && s.Anime.Title == animeName);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }
        
        // localhost/Anime/{animeName}/season-{seasonId}/episode-{episodeId}
        public IActionResult Episode(string animeName, int seasonId, int episodeId)
        {
            Episode episode = _dataContext.Episodes
                .Include(e => e.Season)
                .ThenInclude(s => s.Anime).Include(s => s.Season).ThenInclude(e=> e.Episodes)
                .FirstOrDefault(e => e.Id == episodeId && e.Season.Id == seasonId && e.Season.Anime.Title == animeName);

            if (episode == null)
            {
                return NotFound();
            }

            return View(episode);
        }
        */
        
        [HttpGet]
        public async Task<IActionResult> GetAnime(int id, bool isJson)
        {
            //var response = _dataContext.Anime.Include(s => s.Seasons).FirstOrDefault(x => x.Id == id);
            var response = await _animeRepository.GetByIdAsync(id);
            if (isJson)
            {
                return Json(response);
            }

            return PartialView("_GetAnime", response);
        }
        
    }
}

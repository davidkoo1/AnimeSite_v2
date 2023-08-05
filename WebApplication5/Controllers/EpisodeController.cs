using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class EpisodeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IEpisodeRepository _episodeRepository;
        public EpisodeController(IEpisodeRepository episodeRepository, DataContext dataContext)
        {
            _episodeRepository = episodeRepository;
            _dataContext = dataContext;

        }
        public async Task<IActionResult> Index(string animeName, int seasonId)
        {
            var episodes = await _episodeRepository.GetAllEpisodesBySeason(animeName, seasonId);
            return View(episodes);
        }

        public async Task<IActionResult> About(string animeName, int seasonId, int episodeId)
        {
            Episode episode =  await _episodeRepository.GetByIdAsync(animeName, seasonId, episodeId);
            return View(episode);
        }

        public IActionResult Create(string animeName, int seasonId) => View();


        [HttpPost]
        public async Task<IActionResult> Create(Episode episode)
        {
            /*
            var season = _dataContext.Seasons
                 .Include(a => a.Anime)
                 .ThenInclude(s => s.Seasons)
                 .ThenInclude(s => s.Episodes)
                 .FirstOrDefault(a => a.Anime.Title.Contains(animeName) && a.Id == seasonId);
            episode.SeasonId = seasonId;
            episode.Season = season;
            */
            if (!ModelState.IsValid) 
            {
                return View(episode);
            }
            _episodeRepository.Add(episode);
            return RedirectToAction("Index");
        }
    }
}

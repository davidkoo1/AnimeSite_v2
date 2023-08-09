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
        public async Task<IActionResult> Index(string animeName, int seasonNumber)
        {
            IEnumerable<Episode> episodes = await _episodeRepository.GetAllEpisodesBySeason(animeName, seasonNumber);
            return View(episodes);
        }

        public async Task<IActionResult> About(string animeName, int seasonNumber, int episodeNumber)
        {
            Episode episode =  await _episodeRepository.GetEpisodeAsync(animeName, seasonNumber, episodeNumber);
            return View(episode);
        }

        public IActionResult Create(string animeName, int seasonNumber)
        {
            Episode episode = new Episode()
            {
                AnimeName = animeName,
                SeasonNumber = seasonNumber,
                EpisodeNumber = _dataContext.Episodes.Count(sa => sa.AnimeName == animeName && sa.SeasonNumber == seasonNumber) + 1,

            };
            return View(episode);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Episode episode)
        {
            if (!ModelState.IsValid)
            {
                return View(episode); //Правильно возвр
            }
            _episodeRepository.Add(episode);
            return RedirectToAction("Index", new { animeName = episode.AnimeName, seasonNumber = episode.SeasonNumber });
        }
    }
}

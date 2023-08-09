using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Interfaces;
using WebApplication5.Models;
using WebApplication5.Repository;

namespace WebApplication5.Controllers
{
    public class SeasonController : Controller
    {
        private readonly ISeasonRepository _seasonRepository;
        public SeasonController(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task<IActionResult> Detail(string animeName, int? seasonNumber)
        {
            var seasons = await _seasonRepository.GetSeasonsByAnimeName(animeName);
            /*
            Anime anime = _dataContext.Anime.Include(a => a.Seasons).ThenInclude(e => e.Episodes).FirstOrDefault(a => a.Title == animeName);
            if (anime == null)
            {
                return NotFound();
            }
            */
            ViewBag.SelectSeason = seasonNumber;
            return View("Detail", seasons);
        }
        public IActionResult Create(string animeName)
        {
            Season season = new Season()
            {
                AnimeName = animeName,
                SeasonNumber = _seasonRepository.GetSeasonCount(animeName) + 1,
                Episodes = new List<Episode>()
                {
                    new Episode()
                    {
                        AnimeName = animeName,
                        SeasonNumber = _seasonRepository.GetSeasonCount(animeName) + 1,
                        EpisodeNumber = 1,
                    }
                }

            };
            return View(season);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Season season)
        {
            if (!ModelState.IsValid)
            {
                return View(season); //Правильно возвр
            }
            _seasonRepository.Add(season);
            return RedirectToAction("Detail", new { animeName = season.AnimeName });
        }
    }
}

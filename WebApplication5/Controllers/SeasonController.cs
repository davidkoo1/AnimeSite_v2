using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class SeasonController : Controller
    {
        private readonly ISeasonRepository _seasonRepository;
        public SeasonController(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task<IActionResult> Detail(string animeName, string? seasonName)
        {
            var seasons = await _seasonRepository.GetSeasonsByAnime(animeName);
            /*
            Anime anime = _dataContext.Anime.Include(a => a.Seasons).ThenInclude(e => e.Episodes).FirstOrDefault(a => a.Title == animeName);
            if (anime == null)
            {
                return NotFound();
            }
            */
            ViewBag.SelectSeason = seasonName;
            return View("Detail", seasons);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class SeasonController : Controller
    {
        private readonly DataContext _dataContext;
        public SeasonController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("/Season-{Id}")]
        [ProducesResponseType(200, Type = typeof(Season))]
        public IActionResult Season(string name, int id)
        {
            Season season = _dataContext.Seasons.Include(a => a.Anime).ThenInclude(g => g.AnimeGenres).ThenInclude(g => g.Genre)
                .Include(e => e.Episodes)
                .Include(r => r.Ratings)
                .FirstOrDefault(s => s.Id == id);   

            return View(season);
        }
    }
}

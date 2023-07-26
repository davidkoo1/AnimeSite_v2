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


        public IActionResult Detail(int id)
        {
            Season season = _dataContext.Seasons.Include(a => a.Anime).ThenInclude(g => g.AnimeGenres).ThenInclude(g => g.Genre)
                .Include(e => e.Episodes)
                .Include(r => r.Ratings)
                .FirstOrDefault(s => s.Id == id);   

            return View(season);
        }
    }
}

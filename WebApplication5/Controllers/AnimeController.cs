using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Interfaces;
using WebApplication5.Models;
using WebApplication5.Repository;

namespace WebApplication5.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly DataContext _dataContext;
        public AnimeController(IAnimeRepository animeRepository, DataContext dataContext)
        {
            _animeRepository = animeRepository;
            _dataContext = dataContext; 
        }
        // localhost/
        public async Task<IActionResult> Index()
        {
            var animes =  await _animeRepository.GetAllAnime();
            return View(animes);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAnime(string AnimeName, bool isJson)
        {
            var response = await _animeRepository.GetByNameAsync(AnimeName);
            if (isJson)
            {
                return Json(response);
            }

            return PartialView("_GetAnime", response);
        }


        public IActionResult Create()
        {
            /*
            var model = new Anime()
            {
                Genres = _dataContext.Genres.ToList(),
                Editors = _dataContext.Editors.ToList()
            };*/
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Anime anime)
        {
            //EditorId = select by EditorName
            //Editor.Id select by EditorName or new id
            if (!ModelState.IsValid)
            {
                return View(anime); //Правильно возвр
            }
            _animeRepository.Add(anime);
            return RedirectToAction("Index");
        }
    }
}

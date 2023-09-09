using BLL.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<IActionResult> Index()
        {
            var genres = await _genreRepository.GetAllGenres();
            return View(genres);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre);
            }
            _genreRepository.Add(genre);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(id);
            if (genre == null)
                return View("Error");
            var genreVM = new EditGenreViewModel
            {
                Name = genre.Name

            };
            return View(genreVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditGenreViewModel genreVM)
        {

            var editGenre = await _genreRepository.GetGenreByIdAsyncNoTracking(id);
            if (editGenre != null)
            {
                var genre = new Genre
                {
                    Id = id,
                    Name = genreVM.Name
                };

                _genreRepository.Update(genre);
                return RedirectToAction("Index");
            }
            else { return View(genreVM); }

        }

        public async Task<IActionResult> Delete(int id)
        {
            var genreDetail = await _genreRepository.GetGenreByIdAsync(id);
            if (genreDetail == null)
                return View("Error");
            return View(genreDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genreDetail = await _genreRepository.GetGenreByIdAsync(id);
            if (genreDetail == null)
                return View("Error");

            _genreRepository.Delete(genreDetail);
            return RedirectToAction("Index");
        }
    }
}

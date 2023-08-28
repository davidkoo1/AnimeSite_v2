using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication5.Data;
using WebApplication5.Interfaces;
using WebApplication5.Models;
using WebApplication5.Repository;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly IEditorRepository _editorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IWishListRepository _wishListRepository;
        private readonly IMediaService _mediaService;
        private readonly IHttpContextAccessor _httpContextAccessor; 
        public AnimeController(IAnimeRepository animeRepository, 
            IEditorRepository editorRepository, 
            IGenreRepository genreRepository, 
            IHttpContextAccessor httpContextAccessor, 
            IWishListRepository wishListRepository,
            IMediaService mediaService)
        {
            _animeRepository = animeRepository;
            _editorRepository = editorRepository;
            _genreRepository = genreRepository;
            _httpContextAccessor = httpContextAccessor;
            _wishListRepository = wishListRepository;
            _mediaService = mediaService;
        }
  
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

        public bool IsFavouriteAnime(string animeName, string userId)
        {
            return _wishListRepository.ExistsinVishList(animeName, userId);
        }

        public async Task<IActionResult> Create()
        {
            var publishers = await _editorRepository.GetAllEditors();
            ViewBag.Publishers = publishers;

            var genres = await _genreRepository.GetAllGenres();
            ViewBag.Genres = genres;

            /* var anime = new Anime()
             {
                 Seasons = new List<Season>()
                 {
                     new Season
                     {
                         SeasonNumber = 1,
                         Episodes = new List<Episode>()
                         {
                             new Episode
                             {
                                 SeasonNumber = 1,
                                 EpisodeNumber = 1
                             }
                         }
                     }
                 }
             };*/
            var anime = new CreateAnimeViewModel()
            {
                SeasonVM = new CreateSeasonViewModel() 
                {
                    SeasonNumber = 1,
                    EpisodeVM = new CreateEpisodeViewModel()
                    {
                        SeasonNumber = 1,
                        EpisodeNumber = 1
                    }
                }
            };
            return View(anime);
        }

        //Надо правильно доделать эти методы Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateAnimeViewModel animeVM, int[] selectedGenres)
        {
            animeVM.SeasonVM.AnimeName = animeVM.AnimeName;
            animeVM.SeasonVM.EpisodeVM.AnimeName = animeVM.AnimeName;
            animeVM.AnimeGenres = new List<AnimeGenre>();
            for(int i = 0; i< selectedGenres.Length; i++)
            {
                AnimeGenre tmp = new AnimeGenre()
                {
                    AnimeName = animeVM.AnimeName,
                    GenreId = selectedGenres[i]
                };
                animeVM.AnimeGenres.Add(tmp);
            }
            var anime = new Anime
            {
                EditorId = animeVM.EditorId,
                AnimeName = animeVM.AnimeName,
                Description = animeVM.Description,
                Trailer = animeVM.Trailer,
                AnimeGenres = animeVM.AnimeGenres,

            };
            var season = new Season
            {
                AnimeName = animeVM.AnimeName,
                SeasonNumber = 1,
                SeasonTitle = animeVM.SeasonVM.SeasonTitle,

            };
            var episode = new Episode
            {
                AnimeName= animeVM.AnimeName,
                SeasonNumber = 1,
                EpisodeNumber = 1,

            };
            if (animeVM.SeasonVM.EpisodeVM.EpisodeSrcUpload != null)
            {
                var result = await _mediaService.AddVideoAsync(animeVM.SeasonVM.EpisodeVM.EpisodeSrcUpload);
                episode.EpisodeSrc = result.Url.ToString();
            }
            else if (animeVM.SeasonVM.EpisodeVM.EpisodeSrcLink != null)
            {
                episode.EpisodeSrc = animeVM.SeasonVM.EpisodeVM.EpisodeSrcLink;
            }
            season.Episodes = new List<Episode> { episode };

            if (animeVM.SeasonVM.SeasonImageSrcUpload != null)
            {
                var result = await _mediaService.AddPhotoAsync(animeVM.SeasonVM.SeasonImageSrcUpload);
                season.SeasonImage = result.Url.ToString();
            }
            else if (animeVM.SeasonVM.SeasonImageSrcLink != null)
            {
                season.SeasonImage = animeVM.SeasonVM.SeasonImageSrcLink;
            }
            anime.Seasons = new List<Season> { season };

            if (animeVM.TitleImageUpload != null)
            {
                //if (ModelState.IsValid)
                //{
                    var result = await _mediaService.AddPhotoAsync(animeVM.TitleImageUpload);
                    anime.TitleImage = result.Url.ToString();
                    _animeRepository.Add(anime);
                    return RedirectToAction("Index");
                //}
                /*else
                {
                    ModelState.AddModelError("", "Photo upload failed");
                }
                */
            }
            else if (animeVM.TitleImageLink != null)
            {
               /* if (!ModelState.IsValid)
                {
                    return View("Create");
                }
               */
                anime.TitleImage = animeVM.TitleImageLink;
                    _animeRepository.Add(anime);
                return RedirectToAction("Index");
            }

            return View("Create"); //, animeVM
        }


        public async Task<IActionResult> Edit(string animeName)
        {
            var publishers = await _editorRepository.GetAllEditors();
            ViewBag.Publishers = publishers;

            var genres = await _genreRepository.GetAllGenres();
            ViewBag.Genres = genres;
            var anime = await _animeRepository.GetByNameAsync(animeName);
            if (anime == null)
                return View("Error");
            var animeVM = new EditAnimeViewModel
            {
                AnimeName = animeName,
                Trailer = anime.Trailer,
                EditorId = anime.EditorId,
                TitleImageLink = anime.TitleImage,
                AnimeGenres = anime.AnimeGenres,
                Description = anime.Description

            };
            return View(animeVM);
        }
       
        [HttpPost] //сделать чтобы был PK-Anime, чтобы можно было редачить и имя, сделать чтобы у жанров стояла галочка при изменении
        public async Task<IActionResult> Edit(string animeName, EditAnimeViewModel animeVM, int[] selectedGenres)
        {

            var editAnime = await _animeRepository.GetByNameAsyncNoTraking(animeName);
            if (editAnime != null)
            {
                animeVM.AnimeGenres = new List<AnimeGenre>();
                for (int i = 0; i < selectedGenres.Length; i++)
                {
                    AnimeGenre tmp = new AnimeGenre()
                    {
                        AnimeName = animeVM.AnimeName,
                        GenreId = selectedGenres[i]
                    };
                    animeVM.AnimeGenres.Add(tmp);
                }

                var anime = new Anime
                {
                    AnimeName = animeName,
                    Description = animeVM.Description,
                    Trailer = animeVM.Trailer,
                    EditorId = animeVM.EditorId,
                    AnimeGenres = animeVM.AnimeGenres
                };
                if (animeVM.TitleImageUpload != null)
                {
                    try
                    {
                        await _mediaService.DeletePhotoAsync(editAnime.TitleImage);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Could not delete photo");
                        return View("Edit", animeVM);
                        //return View(editorVM);
                    }

                    var photoRes = await _mediaService.AddPhotoAsync(animeVM.TitleImageUpload);
                    anime.TitleImage = photoRes.Url.ToString();
                }
                else
                {
                    try
                    {
                        await _mediaService.DeletePhotoAsync(editAnime.TitleImage);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Could not delete photo");
                        return View("Edit", animeVM);
                        //return View(editorVM);

                    }
                    anime.TitleImage = animeVM.TitleImageLink;
                }

                _animeRepository.Update(anime);
                return RedirectToAction("Index"); //_GetAnime
            }
            else { return View(animeVM); }

        }

        public async Task<IActionResult> Delete(string animeName)
        {
            var animeDetail = await _animeRepository.GetByNameAsync(animeName);
            if (animeDetail == null)
                return View("Error");
            return View(animeDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteAnime(string animeName)
        {
            var animeDetail = await _animeRepository.GetByNameAsync(animeName);
            if (animeDetail == null)
                return View("Error");

            _animeRepository.Delete(animeDetail);
            return RedirectToAction("Index");
        }

    }
}

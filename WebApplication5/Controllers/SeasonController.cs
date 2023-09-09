using BLL.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class SeasonController : Controller
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly IMediaService _mediaService;

        public SeasonController(ISeasonRepository seasonRepository, IMediaService mediaService)
        {
            _seasonRepository = seasonRepository;
            _mediaService = mediaService;
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
            var sortedSeasons = seasons
    .OrderBy(x => x.SeasonNumber >= 0 ? x.SeasonNumber : int.MaxValue)
    .ThenByDescending(x => x.SeasonNumber < 0 ? x.SeasonNumber : int.MinValue)
    .ToList();
            /*
             например в массиве
                1 -1 2 3 -2
                мы поличим
                1 2 3 -1 -2
            */

            return View("Detail", sortedSeasons);

        }
        public IActionResult Create(string animeName)
        {
            var seasonN = _seasonRepository.GetSeasonCount(animeName) + 1;
            CreateSeasonViewModel season = new CreateSeasonViewModel()
            {

                AnimeName = animeName,
                SeasonNumber = seasonN,
                EpisodeVM = new CreateEpisodeViewModel
                {
                    AnimeName = animeName,
                    SeasonNumber = seasonN,
                    EpisodeNumber = 1,
                }

            };
            return View(season);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateSeasonViewModel seasonVM)
        {
            Episode episode = new Episode()
            {
                AnimeName = seasonVM.AnimeName,
                SeasonNumber = seasonVM.SeasonNumber,
                EpisodeNumber = 1
            };
            if (seasonVM.EpisodeVM.EpisodeSrcUpload != null)
            {
                var result = await _mediaService.AddVideoAsync(seasonVM.EpisodeVM.EpisodeSrcUpload);
                episode.EpisodeSrc = result.Url.ToString();
            }
            else if (seasonVM.EpisodeVM.EpisodeSrcLink != null)
            {
                episode.EpisodeSrc = seasonVM.EpisodeVM.EpisodeSrcLink;
            }
            if (seasonVM.SeasonImageSrcUpload != null)
            {
                if (ModelState.IsValid)
                {
                    var result = await _mediaService.AddPhotoAsync(seasonVM.SeasonImageSrcUpload);
                    var season = new Season
                    {
                        SeasonTitle = seasonVM.SeasonTitle,
                        AnimeName = seasonVM.AnimeName,
                        SeasonNumber = seasonVM.SeasonNumber,
                        SeasonImage = result.Url.ToString(),
                        Episodes = new List<Episode>()
                        {
                            episode
                        }
                    };
                    _seasonRepository.Add(season);
                    return RedirectToAction("Detail", new { animeName = season.AnimeName });
                }
                else
                {
                    ModelState.AddModelError("", "Photo upload failed");
                }
            }
            else if (seasonVM.SeasonImageSrcLink != null)
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", new { animeName = seasonVM.AnimeName });
                }
                var season = new Season
                {
                    SeasonTitle = seasonVM.SeasonTitle,
                    AnimeName = seasonVM.AnimeName,
                    SeasonNumber = seasonVM.SeasonNumber,
                    SeasonImage = seasonVM.SeasonImageSrcLink,
                    Episodes = new List<Episode>()
                        {
                            episode
                        }
                };
                _seasonRepository.Add(season);
                return RedirectToAction("Detail", new { animeName = season.AnimeName });
            }

            return View("Create", new { animeName = seasonVM.AnimeName });
        }


        public async Task<IActionResult> Edit(string animeName, int seasonNumber)
        {
            var season = await _seasonRepository.GetSeasonAsync(animeName, seasonNumber);
            if (season == null)
                return View("Error");
            var seasonVM = new EditSeasonViewModel
            {
                AnimeName = season.AnimeName,
                SeasonNumber = season.SeasonNumber,
                SeasonTitle = season.SeasonTitle,
                SeasonImageSrcLink = season.SeasonImage

            };
            return View(seasonVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string animeName, int seasonNumber, EditSeasonViewModel seasonVM)
        {

            var editSeason = await _seasonRepository.GetSeasonAsyncNoTraking(animeName, seasonNumber);
            if (editSeason != null)
            {
                var season = new Season
                {
                    AnimeName = animeName,
                    SeasonNumber = seasonNumber,
                    SeasonTitle = seasonVM.SeasonTitle
                };
                if (seasonVM.SeasonImageSrcUpload != null)
                {
                    try
                    {
                        await _mediaService.DeletePhotoAsync(editSeason.SeasonImage);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Could not delete photo");
                        return View("Edit", seasonVM);
                        //return View(editorVM);
                    }

                    var photoRes = await _mediaService.AddPhotoAsync(seasonVM.SeasonImageSrcUpload);
                    season.SeasonImage = photoRes.Url.ToString();
                }
                else
                {
                    try
                    {
                        await _mediaService.DeletePhotoAsync(editSeason.SeasonImage);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Could not delete photo");
                        return View("Edit", seasonVM);
                        //return View(editorVM);

                    }
                    season.SeasonImage = seasonVM.SeasonImageSrcLink;
                }

                _seasonRepository.Update(season);
                return RedirectToAction("Detail", new { animeName = season.AnimeName });
            }
            else { return View(seasonVM); }

        }

        public async Task<IActionResult> Delete(string animeName, int seasonNumber)
        {
            var seasonDetail = await _seasonRepository.GetSeasonAsync(animeName, seasonNumber);
            if (seasonDetail == null)
                return View("Error");
            return View(seasonDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteSeason(string animeName, int seasonNumber)
        {
            var seasonDetail = await _seasonRepository.GetSeasonAsync(animeName, seasonNumber);
            if (seasonDetail == null)
                return View("Error");

            _seasonRepository.Delete(seasonDetail);
            return RedirectToAction("Detail", new { animeName = seasonDetail.AnimeName });
        }
    }
}

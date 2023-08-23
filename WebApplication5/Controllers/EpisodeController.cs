using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Interfaces;
using WebApplication5.Models;
using WebApplication5.Repository;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class EpisodeController : Controller
    {

        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMediaService _videoService;

        public EpisodeController(IEpisodeRepository episodeRepository, IMediaService videoService)
        {
            _episodeRepository = episodeRepository;
            _videoService = videoService;
        }
        public async Task<IActionResult> Index(string animeName, int seasonNumber)
        {
            IEnumerable<Episode> episodes = await _episodeRepository.GetAllEpisodesBySeason(animeName, seasonNumber);
            return View(episodes);
        }

        public async Task<IActionResult> About(string animeName, int seasonNumber, int episodeNumber)
        {
            Episode episode = await _episodeRepository.GetEpisodeAsync(animeName, seasonNumber, episodeNumber);
            return View(episode);
        }

        public async Task<IActionResult> Create(string animeName, int seasonNumber)
        {
            CreateEpisodeViewModel episodeVM = new CreateEpisodeViewModel()
            {
                AnimeName = animeName,
                SeasonNumber = seasonNumber,
                EpisodeNumber = await _episodeRepository.CountEpisodes(animeName, seasonNumber) + 1,

            };
            return View(episodeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEpisodeViewModel episodeVM)
        {

            if (episodeVM.EpisodeSrcUpload != null)
            {
                if (ModelState.IsValid)
                {
                    var result = await _videoService.AddVideoAsync(episodeVM.EpisodeSrcUpload);
                    var episode = new Episode
                    {
                        AnimeName = episodeVM.AnimeName,
                        SeasonNumber = episodeVM.SeasonNumber,
                        EpisodeNumber = episodeVM.EpisodeNumber,
                        EpisodeSrc = result.Url.ToString()
                    };
                    _episodeRepository.Add(episode);
                    return RedirectToAction("Index", new { animeName = episode.AnimeName, seasonNumber = episode.SeasonNumber });
                }
                else
                {
                    ModelState.AddModelError("", "Photo upload failed");
                }
            }
            else if (episodeVM.EpisodeSrcLink != null)
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", new { animeName = episodeVM.AnimeName, seasonNumber = episodeVM.SeasonNumber });
                }
                Episode episode = new Episode
                {
                    AnimeName = episodeVM.AnimeName,
                    SeasonNumber = episodeVM.SeasonNumber,
                    EpisodeNumber = episodeVM.EpisodeNumber,
                    EpisodeSrc = episodeVM.EpisodeSrcLink
                };
                _episodeRepository.Add(episode);
                return RedirectToAction("Index", new { animeName = episode.AnimeName, seasonNumber = episode.SeasonNumber });
            }

            return View("Create", new { animeName = episodeVM.AnimeName, seasonNumber = episodeVM.SeasonNumber });
        }

        public async Task<IActionResult> Edit(string animeName, int seasonNumber, int episodeNumber)
        {
            var episode = await _episodeRepository.GetEpisodeAsync(animeName, seasonNumber, episodeNumber);
            if (episode == null)
                return View("Error");
            var episodeVM = new EditEpisodeViewModel
            {
                AnimeName = episode.AnimeName,
                SeasonNumber = episode.SeasonNumber,
                EpisodeNumber = episode.SeasonNumber,
                EpisodeSrcLink = episode.EpisodeSrc

            };
            return View(episodeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string animeName, int seasonNumber, int episodeNumber, EditEpisodeViewModel episodeVM)
        {

            var editEpisode = await _episodeRepository.GetEpisodeAsyncNoTracking(animeName, seasonNumber, episodeNumber);
            if (editEpisode != null)
            {
                var episode = new Episode
                {
                    AnimeName = animeName,
                    SeasonNumber = seasonNumber,
                    EpisodeNumber = episodeNumber
                    //Возможно чтобы мы могли еще редактировать дату(поменять в модели .DataNow())
                };
                if (episodeVM.EpisodeSrcUpload != null)
                {
                    try
                    {
                        await _videoService.DeletePhotoAsync(editEpisode.EpisodeSrc);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Could not delete photo");
                        return View("Edit", episodeVM);
                        //return View(editorVM);
                    }

                    var videoRes = await _videoService.AddVideoAsync(episodeVM.EpisodeSrcUpload);
                    episode.EpisodeSrc = videoRes.Url.ToString();
                }
                else
                {
                    try
                    {
                        await _videoService.DeletePhotoAsync(editEpisode.EpisodeSrc);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Could not delete photo");
                        return View("Edit", episodeVM);
                        //return View(editorVM);
                    }
                    episode.EpisodeSrc = episodeVM.EpisodeSrcLink;
                }

                _episodeRepository.Update(episode);
                return RedirectToAction("About", new { animeName = episode.AnimeName, seasonNumber = episode.SeasonNumber, episodeNumber = episode.EpisodeNumber });
            }
            else { return View(episodeVM); }

        }
    }
}

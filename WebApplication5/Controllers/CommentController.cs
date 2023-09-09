using BLL.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<IActionResult> GetCommentsByEpisode(string AnimeName, int seasonNumber, int episodeNumber)
        {
            var comments = await _commentRepository.GetCommentsByEpisodeAsync(AnimeName, seasonNumber, episodeNumber);
            return PartialView("_Comments", comments);
        }

        [HttpPost]
        public async Task<IActionResult> EpisodeComment(Comment comment)
        {
            if (comment.Message != null)
            {
                _commentRepository.Add(comment);
                return RedirectToAction("About", "Episode", new { animeName = comment.AnimeName, seasonNumber = comment.SeasonNumber, episodeNumber = comment.EpisodeNumber });
            }
            return Json("Error");
        }

        //[HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var commentDetail = await _commentRepository.GetCommentById(id);
            if (commentDetail == null)
                return View("Error");

            _commentRepository.Delete(commentDetail);
            return RedirectToAction("About", "Episode", new { animeName = commentDetail.AnimeName, seasonNumber = commentDetail.SeasonNumber, episodeNumber = commentDetail.EpisodeNumber });
        }

    }
}

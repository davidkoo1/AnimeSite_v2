using Microsoft.AspNetCore.Mvc;
using WebApplication5.Data;

namespace WebApplication5.Controllers
{
    public class CommentController : Controller
    {
        private readonly DataContext  _dataContext;
        public CommentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult GetCommentsByEpisode(string AnimeName, int seasonNumber, int episodeNumber)
        {
            var comments = _dataContext.Comments.Where(c => c.SeasonNumber == seasonNumber && c.EpisodeNumber == episodeNumber && c.AnimeName == AnimeName).ToList();
            return PartialView("_Comments", comments);
        }
    }
}

using DAL.Interfaces;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _dataContext;

        public CommentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool Add(Comment comment)
        {
            _dataContext.Add(comment);
            return Save();
        }

        public bool Delete(Comment comment)
        {
            _dataContext.Remove(comment);
            return Save();
        }

        public async Task<Comment> GetCommentById(Guid id) => await _dataContext.Comments.FirstOrDefaultAsync(x => x.CommentId == id);

        public async Task<IList<Comment>> GetCommentsByEpisodeAsync(string AnimeName, int seasonNumber, int episodeNumber) => await _dataContext.Comments.Where(c => c.SeasonNumber == seasonNumber && c.EpisodeNumber == episodeNumber && c.AnimeName == AnimeName).ToListAsync();

        public bool Save() => _dataContext.SaveChanges() > 0 ? true : false;

        public bool Update(Comment comment)
        {
            _dataContext.Update(comment);
            return Save();
        }
    }
}

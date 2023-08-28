using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsByEpisodeAsync(string AnimeName, int seasonNumber, int episodeNumber);
        Task<Comment> GetCommentById(Guid id);
        bool Add(Comment comment);
        bool Update(Comment comment);
        bool Delete(Comment comment);
        bool Save();
    }
}

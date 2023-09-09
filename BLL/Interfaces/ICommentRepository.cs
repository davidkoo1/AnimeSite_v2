using Domain.Models;

namespace BLL.Interfaces
{
    public interface ICommentRepository
    {
        Task<IList<Comment>> GetCommentsByEpisodeAsync(string AnimeName, int seasonNumber, int episodeNumber);
        Task<Comment> GetCommentById(Guid id);
        bool Add(Comment comment);
        bool Update(Comment comment);
        bool Delete(Comment comment);
        bool Save();
    }
}

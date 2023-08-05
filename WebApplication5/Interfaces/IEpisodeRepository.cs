using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface IEpisodeRepository
    {
        Task<IEnumerable<Episode>> GetAllEpisodesBySeason(string animeName, int seasonId);
        Task<Episode> GetByIdAsync(string animeName, int seasonId, int id);
        bool Add(Episode episode);
        bool Update(Episode episode);
        bool Delete(Episode episode);
        bool Save();
    }
}

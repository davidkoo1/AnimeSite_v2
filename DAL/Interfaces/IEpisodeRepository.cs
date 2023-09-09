using Domain.Models;

namespace DAL.Interfaces
{
    public interface IEpisodeRepository
    {
        Task<IList<Episode>> GetAllEpisodesBySeason(string animeName, int seasonNumber);
        Task<Episode> GetEpisodeAsync(string animeName, int seasonNumber, int episodeNumber);
        Task<Episode> GetEpisodeAsyncNoTracking(string animeName, int seasonNumber, int episodeNumber);
        Task<int> CountEpisodes(string animeName, int seasonNumber);
        bool Add(Episode episode);
        bool Update(Episode episode);
        bool Delete(Episode episode);
        bool Save();
    }
}

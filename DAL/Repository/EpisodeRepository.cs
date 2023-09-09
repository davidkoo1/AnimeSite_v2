using DAL.Interfaces;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly DataContext _dataContext;
        public EpisodeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Add(Episode episode)
        {
            _dataContext.Add(episode);
            return Save();
        }

        public async Task<int> CountEpisodes(string animeName, int seasonNumber) => await _dataContext.Episodes.CountAsync(sa => sa.AnimeName == animeName && sa.SeasonNumber == seasonNumber);

        public bool Delete(Episode episode)
        {
            _dataContext.Remove(episode);
            return Save();
        }

        public async Task<IList<Episode>> GetAllEpisodesBySeason(string animeName, int seasonId) => await _dataContext.Episodes.Where(e => e.SeasonNumber == seasonId && e.Season.Anime.AnimeName == animeName)
            /*.Include(s => s.Season).ThenInclude(a => a.Anime)*/.ToListAsync();

        public async Task<Episode> GetEpisodeAsync(string animeName, int seasonNumber, int episodeNumber) =>
            await _dataContext.Episodes/*.Include(s => s.Season).ThenInclude(a => a.Anime)
            .Include(s => s.Season).ThenInclude(e => e.Episodes).ThenInclude(c => c.Comments).ThenInclude(u => u.User)*/
            .FirstOrDefaultAsync(e => e.EpisodeNumber == episodeNumber && e.SeasonNumber == seasonNumber && e.AnimeName == animeName);

        public async Task<Episode> GetEpisodeAsyncNoTracking(string animeName, int seasonNumber, int episodeNumber) =>
            await _dataContext.Episodes.AsNoTracking().FirstOrDefaultAsync(e => e.EpisodeNumber == episodeNumber && e.SeasonNumber == seasonNumber && e.AnimeName == animeName);

        public bool Save() => _dataContext.SaveChanges() > 0 ? true : false;

        public bool Update(Episode episode)
        {
            _dataContext.Update(episode);
            return Save();
        }
    }
}

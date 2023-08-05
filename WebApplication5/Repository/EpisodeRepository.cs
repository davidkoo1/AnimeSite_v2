using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Repository
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

        public bool Delete(Episode episode)
        {
            _dataContext.Remove(episode);
            return Save();
        }

        public async Task<IEnumerable<Episode>> GetAllEpisodesBySeason(string animeName, int seasonId) => await _dataContext.Episodes.Where(e => e.SeasonId == seasonId && e.Season.Anime.Title.Contains(animeName))
            .Include(s => s.Season).ThenInclude(a => a.Anime).ToListAsync();

        public async Task<Episode> GetByIdAsync(string animeName, int seasonId, int id) => await _dataContext.Episodes
                .Include(e => e.Season)
                .ThenInclude(s => s.Anime).Include(s => s.Season).ThenInclude(e => e.Episodes)
                .FirstOrDefaultAsync(e => e.Id == id && e.Season.Id == seasonId && e.Season.Anime.Title == animeName);

        public bool Save() => _dataContext.SaveChanges() > 0 ? true : false;

        public bool Update(Episode episode)
        {
            _dataContext.Update(episode);
            return Save();
        }
    }
}

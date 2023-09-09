using DAL.Interfaces;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly DataContext _dataContext;
        public SeasonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool Add(Season season)
        {
            _dataContext.Add(season);
            return Save();
        }

        public bool Delete(Season season)
        {
            _dataContext?.Remove(season);
            return Save();
        }

        public async Task<Season> GetSeasonAsync(string animeName, int seasonNumber) => await _dataContext.Seasons/*.Include(s => s.Episodes).Include(a => a.Anime)*/.FirstOrDefaultAsync(i => i.SeasonNumber == seasonNumber && i.Anime.AnimeName == animeName);

        public async Task<Season> GetSeasonAsyncNoTraking(string animeName, int seasonNumber) => await _dataContext.Seasons.AsNoTracking().FirstOrDefaultAsync(i => i.SeasonNumber == seasonNumber && i.Anime.AnimeName == animeName);

        public int GetSeasonCount(string animeName) => _dataContext.Seasons.Count(a => a.AnimeName == animeName);
        public async Task<IList<Season>> GetSeasonsByAnimeName(string animeName) => await _dataContext.Seasons.Where(s => s.Anime.AnimeName == animeName)
            /*.Include(e => e.Episodes)
            .Include(a => a.Anime)*/
            .ToListAsync();


        public bool Save() => _dataContext.SaveChanges() > 0 ? true : false;

        public bool Update(Season season)
        {
            _dataContext.Update(season);
            return Save();
        }
    }
}

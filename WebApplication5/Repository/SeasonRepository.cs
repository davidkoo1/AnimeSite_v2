using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Repository
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

        public async Task<Season> GetByIdAsync(string animeName, int id) => await _dataContext.Seasons.Include(s => s.Episodes).Include(a => a.Anime).FirstOrDefaultAsync(i => i.Id == id && i.Anime.Title == animeName);

        public async Task<IEnumerable<Season>> GetSeasonsByAnime(string animeName) => await _dataContext.Seasons.Where(s => s.Anime.Title.Contains(animeName))
            .Include(e => e.Episodes)
            .Include(a => a.Anime)
            .ToListAsync();


        public bool Save() => _dataContext.SaveChanges() > 0 ? true : false;

        public bool Update(Season season)
        {
            _dataContext.Update(season);
            return Save();
        }
    }
}

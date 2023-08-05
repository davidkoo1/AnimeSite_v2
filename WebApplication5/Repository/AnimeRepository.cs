using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly DataContext _dataContext;
        public AnimeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool Add(Anime anime) => AddFirstSeason(anime);

        private bool AddFirstSeason(Anime anime)
        {
            Season season = new Season()
            {
                Name = "1",
                Date = DateTime.Now,
                TitleImage = "/src",
                AnimeId = anime.Id,
                Anime = anime,
            };
            _dataContext.Add(season);
            _dataContext.Add(anime);
            return Save();
        }

        public bool Delete(Anime anime)
        {
            _dataContext.Remove(anime);
            return Save();
        }

        public async Task<IEnumerable<Anime>> GetAllAnime() => await _dataContext.Anime
                 .Include(a => a.Seasons).ThenInclude(s => s.Ratings)
                 .Include(a => a.Editor)
                 .Include(a => a.AnimeGenres).ThenInclude(ag => ag.Genre).ToListAsync(); // Жанры || Авторы || Сезоны -> серии -> коменты -> юзеры

        public async Task<IEnumerable<Anime>> GetAnimeByEditor(string Editor) => await _dataContext.Anime.Where(e => e.Editor.Name.Contains(Editor)).ToListAsync();
        

        public async Task<IEnumerable<Anime>> GetAnimeByGenres(string[] genres)
        {
            var query = _dataContext.Anime
                .Where(a => a.AnimeGenres.Any(ag => genres.Contains(ag.Genre.Name)))
                .Include(a => a.AnimeGenres)
                .ThenInclude(ag => ag.Genre);

            return await query.ToListAsync();
        }

        public async Task<Anime> GetByIdAsync(int id) => await _dataContext.Anime.Include(a => a.Seasons).FirstOrDefaultAsync(i => i.Id == id);

        public bool Save() => _dataContext.SaveChanges() > 0 ? true : false;

        public bool Update(Anime anime)
        {
            _dataContext.Update(anime);
            return Save();
        }
    }
}

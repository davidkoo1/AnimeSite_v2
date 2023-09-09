using BLL.Interfaces;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repository
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly DataContext _dataContext;

        public AnimeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool Add(Anime anime)
        {
            _dataContext.Animes.Add(anime);
            return Save();
        }
        public bool Delete(Anime anime)
        {
            _dataContext.Remove(anime);
            return Save();
        }

        public async Task<IList<Anime>> GetAllAnime() => await _dataContext.Animes.ToListAsync(); // Жанры || Авторы || Сезоны -> серии -> коменты -> юзеры
        /*
                 .Include(a => a.Seasons).ThenInclude(s => s.Ratings)
                 .Include(a => a.Editor)
                 .Include(a => a.AnimeGenres).ThenInclude(ag => ag.Genre)*/
        public async Task<IList<Anime>> GetAnimeByEditor(string Editor) => await _dataContext.Animes
            .Where(e => e.Editor.Name.Contains(Editor)).ToListAsync();


        public async Task<IList<Anime>> GetAnimeByGenres(string[] genres)
        {
            var query = _dataContext.Animes
                .Where(a => a.AnimeGenres.Any(ag => genres.Contains(ag.Genre.Name)))/*
                .Include(a => a.AnimeGenres)
                .ThenInclude(ag => ag.Genre)*/;

            return await query.ToListAsync();
        }

        public async Task<IList<AnimeGenre>> GetAnimesByGenre(string genre) => await _dataContext.AnimeGenres.Where(x => x.Genre.Name == genre).ToListAsync();

        public async Task<Anime> GetByNameAsync(string AnimeName) => await _dataContext.Animes/*.Include(a => a.Seasons)*/.FirstOrDefaultAsync(i => i.AnimeName == AnimeName);

        public async Task<Anime> GetByNameAsyncNoTraking(string AnimeName) => await _dataContext.Animes.AsNoTracking().FirstOrDefaultAsync(a => a.AnimeName == AnimeName);

        public bool Save() => _dataContext.SaveChanges() > 0 ? true : false;

        public bool Update(Anime anime)
        {
            var genres = _dataContext.AnimeGenres.Where(x => x.AnimeName == anime.AnimeName).ToList();
            if (genres.Count > 0)
                foreach (var genre in genres)
                    _dataContext.AnimeGenres.Remove(genre);
            if (anime.AnimeGenres.Count > 0)
                foreach (var genre in anime.AnimeGenres)
                    _dataContext.AnimeGenres.Add(genre);

            _dataContext.Update(anime);
            return Save();
        }
    }
}

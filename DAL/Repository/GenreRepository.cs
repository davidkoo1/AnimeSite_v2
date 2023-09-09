using DAL.Interfaces;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _dataContext;

        public GenreRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool Add(Genre genre)
        {
            _dataContext.Add(genre);
            return Save();
        }

        public bool Delete(Genre genre)
        {
            _dataContext.Remove(genre);
            return Save();
        }

        public async Task<IList<Genre>> GetAllGenres() =>  await _dataContext.Genres.ToListAsync();

        public async Task<Genre> GetGenreByIdAsync(int Id) => await _dataContext.Genres.FirstOrDefaultAsync(g => g.Id == Id);
        public async Task<Genre> GetGenreByIdAsyncNoTracking(int id) => await _dataContext.Genres.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);

        public bool Save() => _dataContext.SaveChanges() > 0 ? true : false;

        public bool Update(Genre genre)
        {
            _dataContext.Update(genre);
            return Save();
        }
    }
}

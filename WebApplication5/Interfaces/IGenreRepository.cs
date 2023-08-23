using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllGenres();
        Task<Genre> GetGenreByIdAsync(int Id);
        Task<Genre> GetGenreByIdAsyncNoTracking(int Id);
        bool Add(Genre genre);
        bool Update(Genre genre);
        bool Delete(Genre genre);
        bool Save();
    }
}

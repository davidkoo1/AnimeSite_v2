using Domain.Models;

namespace BLL.Interfaces
{
    public interface IGenreRepository
    {
        Task<IList<Genre>> GetAllGenres();
        Task<Genre> GetGenreByIdAsync(int Id);
        Task<Genre> GetGenreByIdAsyncNoTracking(int Id);
        bool Add(Genre genre);
        bool Update(Genre genre);
        bool Delete(Genre genre);
        bool Save();
    }
}

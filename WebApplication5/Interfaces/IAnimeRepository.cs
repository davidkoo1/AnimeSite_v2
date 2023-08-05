using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface IAnimeRepository
    {
        Task<IEnumerable<Anime>> GetAllAnime();
        Task<Anime> GetByIdAsync(int id);
        Task<IEnumerable<Anime>> GetAnimeByGenres(string[] genres);
        Task<IEnumerable<Anime>> GetAnimeByEditor(string Editor);
        bool Add(Anime anime);
        bool Update(Anime anime);
        bool Delete(Anime anime);
        bool Save();
    }
}

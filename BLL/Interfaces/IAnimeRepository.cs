using Domain.Models;

namespace BLL.Interfaces
{
    public interface IAnimeRepository
    {
        Task<IList<Anime>> GetAllAnime();
        Task<Anime> GetByNameAsync(string AnimeName);
        Task<Anime> GetByNameAsyncNoTraking(string AnimeName);
        Task<IList<AnimeGenre>> GetAnimesByGenre(string genre);
        Task<IList<Anime>> GetAnimeByGenres(string[] genres);
        Task<IList<Anime>> GetAnimeByEditor(string Editor);
        bool Add(Anime anime);
        bool Update(Anime anime);
        bool Delete(Anime anime);
        bool Save();
    }
}

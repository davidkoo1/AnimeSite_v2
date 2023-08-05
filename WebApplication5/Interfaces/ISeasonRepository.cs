using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface ISeasonRepository
    {
        Task<Season> GetByIdAsync(string animeName, int id);
        Task<IEnumerable<Season>> GetSeasonsByAnime(string animeName);
        bool Add(Season season);
        bool Update(Season season);
        bool Delete(Season season);
        bool Save();
    }
}

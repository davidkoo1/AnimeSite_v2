using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface ISeasonRepository
    {
        Task<Season> GetSeasonAsync(string animeName, int seasonNumber);
        Task<Season> GetSeasonAsyncNoTraking(string animeName, int seasonNumber);
        Task<IEnumerable<Season>> GetSeasonsByAnimeName(string animeName);

        int GetSeasonCount(string animeName);
        bool Add(Season season);
        bool Update(Season season);
        bool Delete(Season season);
        bool Save();
    }
}

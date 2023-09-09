using Domain.Models;

namespace BLL.Interfaces
{
    public interface ISeasonRepository
    {
        Task<Season> GetSeasonAsync(string animeName, int seasonNumber);
        Task<Season> GetSeasonAsyncNoTraking(string animeName, int seasonNumber);
        Task<IList<Season>> GetSeasonsByAnimeName(string animeName);

        int GetSeasonCount(string animeName);
        bool Add(Season season);
        bool Update(Season season);
        bool Delete(Season season);
        bool Save();
    }
}

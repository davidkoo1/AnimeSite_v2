using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface IRatingRepository
    {
        Task<Rating> GetRating(Rating rating);
        bool Add(Rating rating);
        bool Update(Rating rating);
        bool Delete(Rating rating);
        bool Save();
    }
}

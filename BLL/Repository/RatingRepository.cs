using BLL.Interfaces;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly DataContext _dataContext;

        public RatingRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool Add(Rating rating)
        {
            _dataContext.Add(rating);
            return Save();
        }

        public bool Delete(Rating rating)
        {
            _dataContext.Remove(rating);
            return Save();
        }

        public async Task<Rating> GetRating(Rating rating) => await _dataContext.Ratings
                .FirstOrDefaultAsync(r =>
                    r.AnimeName == rating.AnimeName &&
                    r.SeasonNumber == rating.SeasonNumber &&
                    r.AppUserId == rating.AppUserId);

        public bool Save() => _dataContext.SaveChanges() > 0 ? true : false;

        public bool Update(Rating rating)
        {
            _dataContext.Update(rating);
            return Save();
        }
    }
}

using DAL.Interfaces;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class WishListRepository : IWishListRepository
    {
        private readonly DataContext _dataContext;

        public WishListRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool Add(FavouriteAnime favouriteAnime)
        {
            _dataContext.Add(favouriteAnime);
            return Save();
        }

        public bool Delete(FavouriteAnime favouriteAnime)
        {
            _dataContext.FavouriteAnime.Remove(favouriteAnime);
            return Save();
        }

        public bool ExistsinVishList(string animeName, string id) => _dataContext.FavouriteAnime.Any(fa => fa.AnimeName == animeName && fa.AppUserId == id);

        public async Task<List<FavouriteAnime>> GetAllUserFavouriteAnime()
        {
            // var userFavouriteAnime = _dataContext.FavouriteAnime.Where(fa => fa.User.Id == curUser.ToString())/*.Include(a => a.Anime)*/;
            return null;// userFavouriteAnime.ToList();
        }

        public async Task<FavouriteAnime> GetFavouriteAnime(FavouriteAnime favouriteAnime) => await _dataContext.FavouriteAnime/*.Include(a => a.Anime)*/
            .FirstOrDefaultAsync(fa => fa.User.Id == favouriteAnime.AppUserId && fa.AnimeName == favouriteAnime.AnimeName);

        public bool Save() => _dataContext.SaveChanges() > 0 ? true : false;


    }
}

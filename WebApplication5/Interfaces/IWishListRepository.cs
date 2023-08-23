using System.Diagnostics;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface IWishListRepository
    {
        Task<List<FavouriteAnime>> GetAllUserFavouriteAnime();
        Task<FavouriteAnime> GetFavouriteAnime(FavouriteAnime favouriteAnime);
        bool ExistsinVishList(string animeName, string id);
        bool Add(FavouriteAnime favouriteAnime);
        bool Delete(FavouriteAnime favouriteAnime);
        bool Save();
    }
}

﻿using BLL.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class WishListController : Controller
    {
        private readonly IWishListRepository _wishListRepository;

        public WishListController(IWishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }
        public async Task<IActionResult> Index()
        {
            var userAnime = await _wishListRepository.GetAllUserFavouriteAnime();
            return View(userAnime);
        }

        [HttpPost]
        public async Task<IActionResult> FavouriteAnime(FavouriteAnime favouriteAnime)
        {
            if (_wishListRepository.ExistsinVishList(favouriteAnime.AnimeName, favouriteAnime.AppUserId))
            {
                _wishListRepository.Delete(favouriteAnime);
            }
            else
                _wishListRepository.Add(favouriteAnime);

            return RedirectToAction("Index", "Anime");
        }
    }
}

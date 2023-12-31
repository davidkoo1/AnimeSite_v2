﻿using BLL.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        [HttpPost]
        public async Task<IActionResult> SeasonRating(Rating rating)
        {
            /*дОБАВИТЬ СЕЗОН И ЮЗЕРА*/
            var existingRating = await _ratingRepository.GetRating(rating);

            if (existingRating != null)
            {
                existingRating.Mark = rating.Mark;
                _ratingRepository.Update(existingRating);
            }
            else
            {
                _ratingRepository.Add(rating);
            }

            return RedirectToAction("Detail", "Season", new { animeName = rating.AnimeName });
        }
    }
}

﻿using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface IEpisodeRepository
    {
        Task<IEnumerable<Episode>> GetAllEpisodesBySeason(string animeName, int seasonNumber);
        Task<Episode> GetEpisodeAsync(string animeName, int seasonNumber, int episodeNumber);
        bool Add(Episode episode);
        bool Update(Episode episode);
        bool Delete(Episode episode);
        bool Save();
    }
}

using ExportData.Models;
using System;
using System.Collections.Generic;

namespace ExportData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Editor> editors = DatabaseConnector.GetEditors();
            List<Genre> genres = DatabaseConnector.GetGenres();
            List<Anime> animes = DatabaseConnector.GetAnimes();
            List<AnimeGenres> listAnimeGenres = DatabaseConnector.GetAnimeGenres();
            List<Season> seasons = DatabaseConnector.GetSeasons();
            List<Episode> episodes = DatabaseConnector.GetEpisodes();
            List<User> users = DatabaseConnector.GetUsers();
            List<Roles> roles = DatabaseConnector.GetRoles();
            List<UserRoles> userRoles = DatabaseConnector.GetUserRoles();
            List<Comment> comments = DatabaseConnector.GetComments();
            List<Rating> ratings = DatabaseConnector.GetRatings();


            /*
            foreach (Editor editor in editors)
            {
                DatabaseConnector.AddEditor(editor);
                Console.WriteLine(editor.Name);
            }


            foreach (Genre genre in genres)
            {
                DatabaseConnector.AddGenre(genre);
                Console.WriteLine(genre.Name);
            }

            foreach (Anime anime in animes)
            {
                DatabaseConnector.AddAnime(anime);
                Console.WriteLine(anime.AnimeName);
            }


            foreach (AnimeGenres animeGenres in listAnimeGenres)
            {
                DatabaseConnector.AddAnimeGenres(animeGenres);
                Console.WriteLine(animeGenres.AnimeName + animeGenres.GenreId);
            }


            foreach (Season season in seasons)
            {
                DatabaseConnector.AddSeason(season);
                Console.WriteLine(season.AnimeName + " " + season.SeasonNumber);
            }


            foreach (Episode episode in episodes)
            {
                DatabaseConnector.AddEpisode(episode);
                Console.WriteLine(episode.AnimeName + " " + episode.SeasonNumber + " " + episode.EpisodeNumber);
            }


            foreach (User user in users)
            {
                DatabaseConnector.AddUser(user);
                Console.WriteLine(user.UserName);
            }


            foreach (Roles role in roles)
            {
                DatabaseConnector.AddRole(role);
                Console.WriteLine(role.Name);
            }

            foreach (UserRoles userRole in userRoles)
            {
                DatabaseConnector.AddUserRole(userRole);
                Console.WriteLine(userRole.UserId + " " + userRole.RoleId);
            }


            foreach (Comment comment in comments)
            {
                DatabaseConnector.AddComments(comment);
                Console.WriteLine(comment.Message);
            }


            foreach (Rating rating in ratings)
            {
                DatabaseConnector.AddRating(rating);
                Console.WriteLine(rating.Mark);
            }
            */
        }
    }
}

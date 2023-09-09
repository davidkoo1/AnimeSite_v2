using ExportData.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExportData
{
    public static class DatabaseConnector
    {
        /*
        public static string NewStr = @"Data Source=DESKTOP-IQ404L4;Initial Catalog=KappaAnimeChellenge;Integrated Security=true;";
        private static string OldStr = @"Data Source=SQL5111.site4now.net;Initial Catalog=db_a9e058_adavid;User Id=db_a9e058_adavid_admin;Password=naruto001";
        */
        public static string OldStr = @"Data Source=DESKTOP-IQ404L4;Initial Catalog=KappaAnimeChellenge;Integrated Security=true;";
        private static string NewStr = @"Data Source=SQL6031.site4now.net;Initial Catalog=db_a9e6db_kappaanimedb;User Id=db_a9e6db_kappaanimedb_admin;Password=Naruto001";

        public static List<Editor> GetEditors()
        {
            List<Editor> editors = new List<Editor>();

            using (SqlConnection connection = new SqlConnection(OldStr))
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader dataReader;
                string GetSqlCommand;
                GetSqlCommand = "SELECT * FROM Editors";

                command = new SqlCommand(GetSqlCommand, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Editor editor = new Editor
                    {
                        Id = dataReader.GetInt32(0),
                        Name = dataReader.GetString(1),
                        Image = dataReader.GetString(3)
                    };

                    if (!dataReader.IsDBNull(2))
                    {
                        editor.Description = dataReader.GetString(2);
                    }
                    else
                        editor.Description = ".";

                    editors.Add(editor);
                }



            }

            return editors;
        }

        public static void AddEditor(Editor newEditor)
        {
            using (SqlConnection connection = new SqlConnection(NewStr))
            {
                String query = "INSERT INTO Editors VALUES (@Name, @Description, @Image)"; //функцию бы использовать sql которая

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@Id", newEditor.Id);
                    command.Parameters.AddWithValue("@Name", newEditor.Name);
                    command.Parameters.AddWithValue("@Description", newEditor.Description);
                    command.Parameters.AddWithValue("@Image", newEditor.Image);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public static List<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>();

            using (SqlConnection connection = new SqlConnection(OldStr))
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader dataReader;
                string GetSqlCommand;
                GetSqlCommand = "SELECT * FROM Genres";

                command = new SqlCommand(GetSqlCommand, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Genre genre = new Genre
                    {
                        Id = dataReader.GetInt32(0),
                        Name = dataReader.GetString(1)
                    };

                    genres.Add(genre);
                }



            }

            return genres;
        }

        public static void AddGenre(Genre newGenre)
        {
            using (SqlConnection connection = new SqlConnection(NewStr))
            {
                String query = "INSERT INTO Genres VALUES (@Name)"; //функцию бы использовать sql которая

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@Id", newEditor.Id);
                    command.Parameters.AddWithValue("@Name", newGenre.Name);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public static List<Anime> GetAnimes()
        {
            List<Anime> animes = new List<Anime>();

            using (SqlConnection connection = new SqlConnection(OldStr))
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader dataReader;
                string GetSqlCommand;
                GetSqlCommand = "SELECT * FROM Animes";

                command = new SqlCommand(GetSqlCommand, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Anime anime = new Anime
                    {
                        EditorId = dataReader.GetInt32(0),
                        AnimeName = dataReader.GetString(1),
                        TitleImage = dataReader.GetString(3),
                        Trailer = dataReader.GetString(4)
                    };

                    if (!dataReader.IsDBNull(2))
                    {
                        anime.Description = dataReader.GetString(2);
                    }
                    else
                        anime.Description = "--";

                    animes.Add(anime);
                }



            }

            return animes;
        }

        public static void AddAnime(Anime newAnime)
        {
            using (SqlConnection connection = new SqlConnection(NewStr))
            {
                String query = "INSERT INTO Animes VALUES (@EditorId, @AnimeName, @Description, @TitleImage, @Trailer)"; //функцию бы использовать sql которая

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EditorId", newAnime.EditorId);
                    command.Parameters.AddWithValue("@AnimeName", newAnime.AnimeName);
                    command.Parameters.AddWithValue("@Description", newAnime.Description);
                    command.Parameters.AddWithValue("@TitleImage", newAnime.TitleImage);
                    command.Parameters.AddWithValue("@Trailer", newAnime.Trailer);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public static List<AnimeGenres> GetAnimeGenres()
        {
            List<AnimeGenres> animeGenres = new List<AnimeGenres>();

            using (SqlConnection connection = new SqlConnection(OldStr))
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader dataReader;
                string GetSqlCommand;
                GetSqlCommand = "SELECT * FROM AnimeGenres";

                command = new SqlCommand(GetSqlCommand, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    AnimeGenres animeGenre = new AnimeGenres
                    {
                        AnimeName = dataReader.GetString(0),
                        GenreId = dataReader.GetInt32(1)
                    };

                    animeGenres.Add(animeGenre);
                }



            }

            return animeGenres;
        }

        public static void AddAnimeGenres(AnimeGenres newAnimeGenres)
        {
            using (SqlConnection connection = new SqlConnection(NewStr))
            {
                String query = "INSERT INTO AnimeGenres VALUES (@AnimeName, @GenreId)"; //функцию бы использовать sql которая

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@AnimeName", newAnimeGenres.AnimeName);
                    command.Parameters.AddWithValue("@GenreId", newAnimeGenres.GenreId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public static List<Season> GetSeasons()
        {
            List<Season> seasons = new List<Season>();

            using (SqlConnection connection = new SqlConnection(OldStr))
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader dataReader;
                string GetSqlCommand;
                GetSqlCommand = "SELECT * FROM Seasons";

                command = new SqlCommand(GetSqlCommand, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Season season = new Season
                    {
                        AnimeName = dataReader.GetString(0),
                        SeasonNumber = dataReader.GetInt32(1),
                        SeasonTitle = dataReader.GetString(2),
                        SeasonImage = dataReader.GetString(3)
                    };

                    seasons.Add(season);
                }



            }

            return seasons;
        }

        public static void AddSeason(Season newSeason)
        {
            using (SqlConnection connection = new SqlConnection(NewStr))
            {
                String query = "INSERT INTO Seasons VALUES (@AnimeName, @SeasonNumber, @SeasonTitle, @SeasonImage)"; //функцию бы использовать sql которая

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AnimeName", newSeason.AnimeName);
                    command.Parameters.AddWithValue("@SeasonNumber", newSeason.SeasonNumber);
                    command.Parameters.AddWithValue("@SeasonTitle", newSeason.SeasonTitle);
                    command.Parameters.AddWithValue("@SeasonImage", newSeason.SeasonImage);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public static List<Episode> GetEpisodes()
        {
            List<Episode> episodes = new List<Episode>();

            using (SqlConnection connection = new SqlConnection(OldStr))
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader dataReader;
                string GetSqlCommand;
                GetSqlCommand = "SELECT * FROM Episodes";

                command = new SqlCommand(GetSqlCommand, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Episode episode = new Episode
                    {
                        AnimeName = dataReader.GetString(0),
                        SeasonNumber = dataReader.GetInt32(1),
                        EpisodeNumber = dataReader.GetInt32(2),
                        EpisodeSrc = dataReader.GetString(3),
                        Date = dataReader.GetDateTime(4)
                    };

                    episodes.Add(episode);
                }



            }

            return episodes;
        }

        public static void AddEpisode(Episode newEpisode)
        {
            using (SqlConnection connection = new SqlConnection(NewStr))
            {
                String query = "INSERT INTO Episodes VALUES (@AnimeName, @SeasonNumber, @EpisodeNumber, @EpisodeSrc, @ReleaseEpisode)"; //функцию бы использовать sql которая

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AnimeName", newEpisode.AnimeName);
                    command.Parameters.AddWithValue("@SeasonNumber", newEpisode.SeasonNumber);
                    command.Parameters.AddWithValue("@EpisodeNumber", newEpisode.EpisodeNumber);
                    command.Parameters.AddWithValue("@EpisodeSrc", newEpisode.EpisodeSrc);
                    command.Parameters.AddWithValue("@ReleaseEpisode", newEpisode.Date);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(OldStr))
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader dataReader;
                string GetSqlCommand;
                GetSqlCommand = "SELECT * FROM AspNetUsers";

                command = new SqlCommand(GetSqlCommand, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    User user = new User
                    {
                        Id = dataReader.GetString(0),
                        UserName = dataReader.GetString(2),
                        NormalizedUserName = dataReader.GetString(3),
                        Email = dataReader.GetString(4),
                        NormalizedEmail = dataReader.GetString(5),
                        EmailConfirmed = dataReader.GetBoolean(6),
                        PasswordHash = dataReader.GetString(7),
                        SecurityStamp = dataReader.GetString(8),
                        ConcurrencyStamp = dataReader.GetString(9),
                        PhoneNumberConfirmed = dataReader.GetBoolean(11),
                        TwoFactorEnabled = dataReader.GetBoolean(12),
                        LockoutEnabled = dataReader.GetBoolean(14),
                        AccessFailedCount = dataReader.GetInt32(15)

                    };
                    user.ProfileImage = (!dataReader.IsDBNull(1)) ? dataReader.GetString(1) : "NULL";
                    user.PhoneNumber = (!dataReader.IsDBNull(10)) ? dataReader.GetString(10) : "NULL";
                    user.LockoutEnd = (!dataReader.IsDBNull(13)) ? dataReader.GetDateTimeOffset(13) : DateTimeOffset.Now;

                    users.Add(user);
                }



            }

            return users;
        }
        
        public static void AddUser(User newUser)
        {
            using (SqlConnection connection = new SqlConnection(NewStr))
            {
                String query = "INSERT INTO AspNetUsers VALUES " +
                    "(@Id, @ProfileImage, @UserName, @NormalizedUserName, @Email, @NormalizedEmail, @EmailConfirmed, @PasswordHash, @SecurityStamp, @ConcurrencyStamp, @PhoneNumber, @PhoneNumberConfirmed, @TwoFactorEnabled, @LockoutEnd, @LockoutEnabled, @AccessFailedCount)"; //функцию бы использовать sql которая

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", newUser.Id);
                    command.Parameters.AddWithValue("@ProfileImage", newUser.ProfileImage);
                    command.Parameters.AddWithValue("@UserName", newUser.UserName);
                    command.Parameters.AddWithValue("@NormalizedUserName", newUser.NormalizedUserName);
                    command.Parameters.AddWithValue("@Email", newUser.Email);
                    command.Parameters.AddWithValue("@NormalizedEmail", newUser.NormalizedEmail);
                    command.Parameters.AddWithValue("@EmailConfirmed", newUser.EmailConfirmed);
                    command.Parameters.AddWithValue("@PasswordHash", newUser.PasswordHash);
                    command.Parameters.AddWithValue("@SecurityStamp", newUser.SecurityStamp);
                    command.Parameters.AddWithValue("@ConcurrencyStamp", newUser.ConcurrencyStamp);
                    command.Parameters.AddWithValue("@PhoneNumber", newUser.PhoneNumber);
                    command.Parameters.AddWithValue("@PhoneNumberConfirmed", newUser.PhoneNumberConfirmed);
                    command.Parameters.AddWithValue("@TwoFactorEnabled", newUser.TwoFactorEnabled);
                    command.Parameters.AddWithValue("@LockoutEnd", newUser.LockoutEnd);
                    command.Parameters.AddWithValue("@LockoutEnabled", newUser.LockoutEnabled);
                    command.Parameters.AddWithValue("@AccessFailedCount", newUser.AccessFailedCount);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public static List<UserRoles> GetUserRoles()
        {
            List<UserRoles> roles = new List<UserRoles>();

            using (SqlConnection connection = new SqlConnection(OldStr))
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader dataReader;
                string GetSqlCommand;
                GetSqlCommand = "SELECT * FROM AspNetUserRoles";

                command = new SqlCommand(GetSqlCommand, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    UserRoles role = new UserRoles
                    {
                        UserId = dataReader.GetString(0),
                        RoleId = dataReader.GetString(1),
                    };

                    roles.Add(role);
                }



            }

            return roles;
        }

        public static void AddUserRole(UserRoles newUserRole)
        {
            using (SqlConnection connection = new SqlConnection(NewStr))
            {
                String query = "INSERT INTO AspNetUserRoles VALUES (@UserId, @RoleId)"; //функцию бы использовать sql которая

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", newUserRole.UserId);
                    command.Parameters.AddWithValue("@RoleId", newUserRole.RoleId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }       


        public static List<Roles> GetRoles()
        {
            List<Roles> roles = new List<Roles>();

            using (SqlConnection connection = new SqlConnection(OldStr))
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader dataReader;
                string GetSqlCommand;
                GetSqlCommand = "SELECT * FROM AspNetRoles";

                command = new SqlCommand(GetSqlCommand, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Roles role = new Roles
                    {
                        Id = dataReader.GetString(0),
                        Name = dataReader.GetString(1),
                        NormalizedName = dataReader.GetString(2),
                        ConcurrencyStamp = dataReader.GetString(3)
                    };

                    roles.Add(role);
                }



            }

            return roles;
        }

        public static void AddRole(Roles newRole)
        {
            using (SqlConnection connection = new SqlConnection(NewStr))
            {
                String query = "INSERT INTO AspNetRoles VALUES (@Id, @Name, @NormalizedName, @ConcurrencyStamp)"; //функцию бы использовать sql которая

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", newRole.Id);
                    command.Parameters.AddWithValue("@Name", newRole.Name);
                    command.Parameters.AddWithValue("@NormalizedName", newRole.NormalizedName);
                    command.Parameters.AddWithValue("@ConcurrencyStamp", newRole.ConcurrencyStamp);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public static List<Comment> GetComments()
        {
            List<Comment> comments = new List<Comment>();

            using (SqlConnection connection = new SqlConnection(OldStr))
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader dataReader;
                string GetSqlCommand;
                GetSqlCommand = "SELECT * FROM Comments";

                command = new SqlCommand(GetSqlCommand, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Comment comment = new Comment
                    {
                        Id = dataReader.GetGuid(0),
                        AnimeName = dataReader.GetString(1),
                        SeasonNumber = dataReader.GetInt32(2),
                        EpisodeNumber = dataReader.GetInt32(3),
                        AppUserId = dataReader.GetString(4),
                        Message = dataReader.GetString(5),
                        Date = dataReader.GetDateTime(6)
                    };

                    comments.Add(comment);
                }



            }

            return comments;
        }

        public static void AddComments(Comment newComment)
        {
            using (SqlConnection connection = new SqlConnection(NewStr))
            {
                String query = "INSERT INTO Comments VALUES (@Id, @AnimeName, @SeasonNumber, @EpisodeNumber, @AppUserId, @Message, @Date)"; //функцию бы использовать sql которая

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Id", newComment.Id);
                    command.Parameters.AddWithValue("@AnimeName", newComment.AnimeName);
                    command.Parameters.AddWithValue("@SeasonNumber", newComment.SeasonNumber);
                    command.Parameters.AddWithValue("@EpisodeNumber", newComment.EpisodeNumber);
                    command.Parameters.AddWithValue("@AppUserId", newComment.AppUserId);
                    command.Parameters.AddWithValue("@Message", newComment.Message);
                    command.Parameters.AddWithValue("@Date", newComment.Date);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        } 
        
        
        public static List<Rating> GetRatings()
        {
            List<Rating> ratings = new List<Rating>();

            using (SqlConnection connection = new SqlConnection(OldStr))
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader dataReader;
                string GetSqlCommand;
                GetSqlCommand = "SELECT * FROM Ratings";

                command = new SqlCommand(GetSqlCommand, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Rating rating = new Rating
                    {
                        AnimeName = dataReader.GetString(0),
                        SeasonNumber = dataReader.GetInt32(1),
                        AppUserId = dataReader.GetString(2),
                        Mark = dataReader.GetInt32(3)
                    };

                    ratings.Add(rating);
                }



            }

            return ratings;
        }

        public static void AddRating(Rating newRating)
        {
            using (SqlConnection connection = new SqlConnection(NewStr))
            {
                String query = "INSERT INTO Ratings VALUES (@AnimeName, @SeasonNumber, @AppUserId, @Mark)"; //функцию бы использовать sql которая

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@AnimeName", newRating.AnimeName);
                    command.Parameters.AddWithValue("@SeasonNumber", newRating.SeasonNumber);
                    command.Parameters.AddWithValue("@AppUserId", newRating.AppUserId);
                    command.Parameters.AddWithValue("@Mark", newRating.Mark);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}

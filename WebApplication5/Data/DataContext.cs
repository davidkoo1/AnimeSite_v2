using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Anime> Animes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<AnimeGenre> AnimeGenres { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Editor> Editors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<FavouriteAnime> FavouriteAnime { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            /* modelBuilder.Entity<AnimeGenre>().HasKey(ag => new { ag.AnimeName, ag.GenreId });
             modelBuilder.Entity<AnimeGenre>().HasOne(a => a.Anime).WithMany(ag => ag.AnimeGenres).HasForeignKey(a => a.AnimeName);
             modelBuilder.Entity<AnimeGenre>().HasOne(a => a.Genre).WithMany(ag => ag.AnimeGenres).HasForeignKey(g => g.GenreId);

             modelBuilder.Entity<Comment>().HasKey(c => new { c.EpisodeId, c.UserId });
             modelBuilder.Entity<Rating>().HasKey(r => new { r.SeasonId, r.UserId });
             modelBuilder.Entity<Episode>().HasKey(e => new { e.AnimeName, e.NumberSeason, e.NumberEpisode });
             modelBuilder.Entity<Season>().HasKey(s => new { s.AnimeName, s.SeasonNumber });

             // Configure IdentityUserLogin<string> as a keyless entity type
             modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();

             
            */
            base.OnModelCreating(modelBuilder); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }


    }
}

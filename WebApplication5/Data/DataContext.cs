using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Anime> Anime { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<AnimeGenre> AnimeGenres { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Editor> Editors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeGenre>().HasKey(ag => new { ag.AnimeId, ag.GenreId });
            modelBuilder.Entity<AnimeGenre>().HasOne(a => a.Anime).WithMany(ag => ag.AnimeGenres).HasForeignKey(a => a.AnimeId);
            modelBuilder.Entity<AnimeGenre>().HasOne(a => a.Genre).WithMany(ag => ag.AnimeGenres).HasForeignKey(g => g.GenreId);

        }

    }
}

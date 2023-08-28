﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication5.Data;

#nullable disable

namespace WebApplication5.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230825145238_ServerDB")]
    partial class ServerDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WebApplication5.Models.Anime", b =>
                {
                    b.Property<string>("AnimeName")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EditorId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("TitleImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimeName");

                    b.HasIndex("EditorId");

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("WebApplication5.Models.AnimeGenre", b =>
                {
                    b.Property<string>("AnimeName")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("AnimeName", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("AnimeGenres");
                });

            modelBuilder.Entity("WebApplication5.Models.Comment", b =>
                {
                    b.Property<Guid>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<string>("AnimeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EpisodeNumber")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("AnimeName", "SeasonNumber", "EpisodeNumber");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WebApplication5.Models.Editor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Editors");
                });

            modelBuilder.Entity("WebApplication5.Models.Episode", b =>
                {
                    b.Property<string>("AnimeName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("int");

                    b.Property<int>("EpisodeNumber")
                        .HasColumnType("int");

                    b.Property<string>("EpisodeSrc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseEpisode")
                        .HasColumnType("datetime2");

                    b.HasKey("AnimeName", "SeasonNumber", "EpisodeNumber");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("WebApplication5.Models.FavouriteAnime", b =>
                {
                    b.Property<string>("AnimeName")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("AnimeName", "AppUserId");

                    b.HasIndex("AppUserId");

                    b.ToTable("FavouriteAnime");
                });

            modelBuilder.Entity("WebApplication5.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("WebApplication5.Models.Rating", b =>
                {
                    b.Property<string>("AnimeName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("int");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.HasKey("AnimeName", "SeasonNumber", "AppUserId");

                    b.HasIndex("AppUserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("WebApplication5.Models.Season", b =>
                {
                    b.Property<string>("AnimeName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("int");

                    b.Property<string>("SeasonImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeasonTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimeName", "SeasonNumber");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("WebApplication5.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApplication5.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApplication5.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication5.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApplication5.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication5.Models.Anime", b =>
                {
                    b.HasOne("WebApplication5.Models.Editor", "Editor")
                        .WithMany("Animes")
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editor");
                });

            modelBuilder.Entity("WebApplication5.Models.AnimeGenre", b =>
                {
                    b.HasOne("WebApplication5.Models.Anime", "Anime")
                        .WithMany("AnimeGenres")
                        .HasForeignKey("AnimeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication5.Models.Genre", "Genre")
                        .WithMany("AnimeGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("WebApplication5.Models.Comment", b =>
                {
                    b.HasOne("WebApplication5.Models.User", "User")
                        .WithMany("Comment")
                        .HasForeignKey("AppUserId");

                    b.HasOne("WebApplication5.Models.Episode", "Episode")
                        .WithMany("Comments")
                        .HasForeignKey("AnimeName", "SeasonNumber", "EpisodeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Episode");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication5.Models.Episode", b =>
                {
                    b.HasOne("WebApplication5.Models.Season", "Season")
                        .WithMany("Episodes")
                        .HasForeignKey("AnimeName", "SeasonNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");
                });

            modelBuilder.Entity("WebApplication5.Models.FavouriteAnime", b =>
                {
                    b.HasOne("WebApplication5.Models.Anime", "Anime")
                        .WithMany("FavouriteAnime")
                        .HasForeignKey("AnimeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication5.Models.User", "User")
                        .WithMany("FavouriteAnime")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication5.Models.Rating", b =>
                {
                    b.HasOne("WebApplication5.Models.User", "User")
                        .WithMany("Rating")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication5.Models.Season", "Season")
                        .WithMany("Ratings")
                        .HasForeignKey("AnimeName", "SeasonNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication5.Models.Season", b =>
                {
                    b.HasOne("WebApplication5.Models.Anime", "Anime")
                        .WithMany("Seasons")
                        .HasForeignKey("AnimeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");
                });

            modelBuilder.Entity("WebApplication5.Models.Anime", b =>
                {
                    b.Navigation("AnimeGenres");

                    b.Navigation("FavouriteAnime");

                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("WebApplication5.Models.Editor", b =>
                {
                    b.Navigation("Animes");
                });

            modelBuilder.Entity("WebApplication5.Models.Episode", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("WebApplication5.Models.Genre", b =>
                {
                    b.Navigation("AnimeGenres");
                });

            modelBuilder.Entity("WebApplication5.Models.Season", b =>
                {
                    b.Navigation("Episodes");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("WebApplication5.Models.User", b =>
                {
                    b.Navigation("Comment");

                    b.Navigation("FavouriteAnime");

                    b.Navigation("Rating");
                });
#pragma warning restore 612, 618
        }
    }
}
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Helpers;
using WebApplication5.Interfaces;
using WebApplication5.Models;
using WebApplication5.Repository;
using WebApplication5.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
builder.Services.AddScoped<ISeasonRepository, SeasonRepository>();
builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>();
builder.Services.AddScoped<IEditorRepository, EditorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IWishListRepository, WishListRepository>();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddScoped<IMediaService, MediaService>();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 9; // Minimum length
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
}).AddEntityFrameworkStores<DataContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       .AddCookie();

builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 100 * 1024 * 1024; // Например, установите максимальный размер в 100 МБ
});

var app = builder.Build();

/*
if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
   await Seed.SeedUsersAndRolesAsync(app);
    //Seed.SeedData(app);
}
*/


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
app.MapBlazorHub();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Anime}/{action=Index}/{id?}");


app.Run();

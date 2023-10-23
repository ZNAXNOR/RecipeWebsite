using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Helpers;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Repository;
using RecipeWebsite.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Project Services

// Collection
builder.Services.AddScoped<ICollectionInterface, CollectionRepository>();

// Post
builder.Services.AddScoped<IPostInterface, PostRepository>();

// Photo
builder.Services.AddScoped<IPhotoInterface, PhotoService>();

var CloudinaryDatabase = builder.Configuration.GetSection("CloudinarySettings");
builder.Services.Configure<CloudinarySettings>(CloudinaryDatabase);

// Database
var MSSQLdatabase = builder.Configuration.GetConnectionString("Database_Connection");
builder.Services.AddDbContext<ApplicationDbContext>(options => {options.UseSqlServer(MSSQLdatabase);
});

// Email
builder.Services.AddTransient<IEmailSenderInterface, EmailSenderService>();
builder.Services.Configure<EmailHelper>(builder.Configuration.GetSection("SMTP_Credentials"));

#endregion

var app = builder.Build();

// Seed
if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    // Seed.SeedUsersAndRolesAsync(app);
    Seed.SeedData(app);
}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

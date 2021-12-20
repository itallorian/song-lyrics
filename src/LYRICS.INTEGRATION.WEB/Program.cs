using LYRICS.INTEGRATION.DOMAIN.Factories;
using LYRICS.INTEGRATION.DOMAIN.Factories.Interfaces;
using LYRICS.INTEGRATION.DOMAIN.Services.Integration;
using LYRICS.INTEGRATION.DOMAIN.Services.Interfaces.Integration;
using LYRICS.INTEGRATION.DOMAIN.Services.Interfaces.LyricsOvh;
using LYRICS.INTEGRATION.DOMAIN.Services.LyricsOvh;
using LYRICS.INTEGRATION.REPOSITORY.Repositories.Intefaces.Integration;
using LYRICS.INTEGRATION.REPOSITORY.Repositories.Integration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region [ SERVICES ]

builder.Services.AddScoped<ILyricsSearchFactory, LyricsSearchFactory>();
builder.Services.AddScoped<ILyricsSearchService, LyricsSearchService>();
builder.Services.AddScoped<ILyricsOvhService, LyricsOvhService>();

#endregion [ SERVICES ]

#region [ REPOSITORIES ]

builder.Services.AddScoped<ILyricsSearchRepository, LyricsSearchRepository>();

#endregion [ REPOSITORIES ]

var app = builder.Build();

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

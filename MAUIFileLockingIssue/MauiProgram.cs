using CommunityToolkit.Maui;
using EFTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MAUIFileLockingIssue;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "EFTest.db");
        builder.Services.AddDbContext<EFTestDbContext>(options =>
        {
            options.UseSqlite($"Filename={dbPath}");
        });

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        var appBuild =  builder.Build();

        // Perform EF migrations
        var context = appBuild.Services.GetRequiredService<EFTestDbContext>();
        context.Database.Migrate();
        context.SaveChanges();

        return appBuild;
    }
}

using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Syncfusion.Maui.Core.Hosting;
using Supabase;
using udemyMAUI1.MVVM.ViewModels;
using udemyMAUI1.Helper;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Geocoding.Google;
using udemyMAUI1.Repositories;
using udemyMAUI1.MVVM.Models;


namespace udemyMAUI1
{

    /// <summary>
    /// Super Cooles Programm
    /// </summary>
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var googleGeocoderApiKey = Properties.Resources.googleGeocoderApiKey;
            var supabaseUrl = Properties.Resources.supabaseUrl;
            var supabaseKey = Properties.Resources.supabaseKey;
            var supabaseOptions = new SupabaseOptions
            {
                AutoRefreshToken = true,
                AutoConnectRealtime = true,
                SessionHandler = new SupabaseSessionHandler()
            };

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseSkiaSharp()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Roboto-Black.ttf", "Strong");
                    fonts.AddFont("LibreFranklin-Regular.ttf", "Regular");

                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Cakecafe.ttf", "Cakecafe");
                    fonts.AddFont("Cheeky Rabbit.ttf", "CheekyRabbit");
                    fonts.AddFont("Comics Tricks.ttf", "ComicsTricks");
                    fonts.AddFont("Dark Poestry.ttf", "DarkPoestry");
                    fonts.AddFont("Mabook.ttf", "Mabook");
                    fonts.AddFont("Next Sunday.ttf", "NextSunday");
                    fonts.AddFont("Wigglye.ttf", "Wigglye");

                    fonts.AddFont("BlackCastleMF.ttf", "BlackCastle");
                    fonts.AddFont("Burn.otf", "Burn");
                    fonts.AddFont("Deutsch.ttf", "Deutsch");
                    fonts.AddFont("Game Of Squids.ttf", "GameOfSquids");
                    fonts.AddFont("good timing bd.otf", "GoodTiming");
                    fonts.AddFont("Plank.ttf", "Plank");
                    fonts.AddFont("SnowtopCaps.otf", "SnowtopCaps");
                    fonts.AddFont("fontello.ttf", "Icons");
                    fonts.AddFont("m_icons.ttf", "MIcons");
                })
                .Services
                    .AddSingleton(provider => new Supabase.Client(supabaseUrl, supabaseKey, supabaseOptions))
                    .AddSingleton(provider =>
                    {
                        var vm = new SupabaseViewModel(provider.GetService<Supabase.Client>());
                        vm.Init();
                        return vm;
                    })
                    .AddSingleton(provider => new GoogleGeocoder() { ApiKey = googleGeocoderApiKey })
                    .AddSingleton<BaseRepository<Transaction>>();

#if DEBUG
            builder.Logging.AddDebug();
#endif



            var app = builder.Build();
            ServiceHelper.Initialize(app.Services);
            return app;
        }
    }
}

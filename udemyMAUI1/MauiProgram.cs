using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace udemyMAUI1
{

    /// <summary>
    /// Super Cooles Programm
    /// </summary>
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>().UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
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
                    fonts.AddFont("Burn.ttf", "Burn");
                    fonts.AddFont("Deutsch.ttf", "Deutsch");
                    fonts.AddFont("Game Of Squids.ttf", "GameOfSquids");
                    fonts.AddFont("good timing bd.otf", "GoodTiming");
                    fonts.AddFont("PLANK__.TTF", "Plank");
                    fonts.AddFont("SnowtopCaps.otf", "SnowtopCaps");
                    fonts.AddFont("fontello.ttf", "Icons");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

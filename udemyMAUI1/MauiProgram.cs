﻿using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Supabase;
using System;

namespace udemyMAUI1
{

    /// <summary>
    /// Super Cooles Programm
    /// </summary>
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var supabaseUrl = "https://tnnhotmumailhbhlbxir.supabase.co";
            var supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InRubmhvdG11bWFpbGhiaGxieGlyIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDE5ODA2NjgsImV4cCI6MjA1NzU1NjY2OH0.U83KNA4X_vf3Us0AY_ON54gmWU_c4KXbqFP1ae66acs";
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
                    fonts.AddFont("Burn.otf", "Burn");
                    fonts.AddFont("Deutsch.ttf", "Deutsch");
                    fonts.AddFont("Game Of Squids.ttf", "GameOfSquids");
                    fonts.AddFont("good timing bd.otf", "GoodTiming");
                    fonts.AddFont("Plank.ttf", "Plank");
                    fonts.AddFont("SnowtopCaps.otf", "SnowtopCaps");
                    fonts.AddFont("fontello.ttf", "Icons");
                })
                .Services.AddSingleton(provider => new Supabase.Client(supabaseUrl, supabaseKey, supabaseOptions));

#if DEBUG
            builder.Logging.AddDebug();
#endif



            return builder.Build();
        }
    }
}

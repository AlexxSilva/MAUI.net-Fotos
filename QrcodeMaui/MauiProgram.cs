﻿using Camera.MAUI;
using Microsoft.Extensions.Logging;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

#if ANDROID
[assembly: Android.App.UsesPermission(Android.Manifest.Permission.Camera)]
#endif

namespace TakeFoto
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCameraView()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
           
            return builder.Build();
        }
    }
}

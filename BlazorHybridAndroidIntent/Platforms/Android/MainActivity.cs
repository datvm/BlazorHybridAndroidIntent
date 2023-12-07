using Android.App;
using Android.Content.PM;
using Android.OS;

using Intent = Android.Content.Intent;
using MauiApp = Microsoft.Maui.Controls.Application;

namespace BlazorHybridAndroidIntent;
[Activity(
    Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density
    , LaunchMode = LaunchMode.SingleTop
)]
[IntentFilter(
    [Intent.ActionView,],
    Categories = [Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryOpenable,],
    DataSchemes = ["file", "content", "http", "https"],
    DataHost = "*",
    DataMimeType = "*/*")]
public class MainActivity : MauiAppCompatActivity
{

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        ProcessIntent(Intent);
    }

    protected override void OnNewIntent(Intent? intent)
    {
        base.OnNewIntent(intent);

        ProcessIntent(intent);
    }

    void ProcessIntent(Intent? intent)
    {
        if (intent is null ||
            intent.Action != Intent.ActionView)
        {
            return;
        }

        var path = intent.Data;
        if (path is null) { return; }

        var dataState = MauiApp.Current?.Handler.MauiContext?.Services
            .GetRequiredService<DataStateService>();
        if (dataState is null) { return; }

        dataState.File = path.ToString()!;
    }

}

using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.IO;

namespace PersonalExpenses.Droid
{
    [Activity(Label = "PersonalExpenses", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CurrentPlatform.Init();

            string databaseFile = "contactos.db3";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string fullPath = Path.Combine(folderPath, databaseFile);

            LoadApplication(new App(fullPath));

           //LoadApplication(new App());
        }
    }
}


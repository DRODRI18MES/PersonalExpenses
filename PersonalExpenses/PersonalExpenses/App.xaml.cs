using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using Microsoft.WindowsAzure.MobileServices;
using PersonalExpenses.Resources;
using PersonalExpenses.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace PersonalExpenses
{
	public partial class App : Application
	{
        public static string DatabasePath;

        public static MobileServiceClient mobileServiceClient = new MobileServiceClient("https://personalexp.azurewebsites.net");

        public App()
        {
            InitializeComponent();
            AppResources.Culture = new System.Globalization.CultureInfo("es-MX");
            MainPage = new NavigationPage(new MainPage());
        }

        public App (string databasePath)
		{
			InitializeComponent();
            DatabasePath = databasePath;
            AppResources.Culture = new System.Globalization.CultureInfo("es-MX");
            MainPage = new NavigationPage(new MainPage());            
        }

		protected override void OnStart ()
		{
            AppCenter.Start("ios=420f1ba6-0a3c-4789-b6c3-e68d8044cfe8;android=0031f62e-577d-4c3f-81fe-c98f50db165d", typeof(Analytics), typeof(Push), typeof(Crashes));
            string test = "";
            Analytics.TrackEvent("Start");
            Crashes.TrackError(new Exception("Test exception"));
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

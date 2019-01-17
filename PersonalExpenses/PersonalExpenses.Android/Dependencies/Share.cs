using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using PersonalExpenses.Droid.Dependencies;
using PersonalExpenses.ViewModel.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace PersonalExpenses.Droid.Dependencies
{
    public class Share : IShare
    {
        public Task Show(string title, string message, string path)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            var fileUri = FileProvider.GetUriForFile(Forms.Context.ApplicationContext, "com.MES.PersonalExpenses.provider", new Java.IO.File(path));

            intent.PutExtra(Intent.ExtraStream, fileUri);
            intent.PutExtra(Intent.ExtraTitle, title);
            intent.PutExtra(Intent.ExtraText, message);

            var chooser = Intent.CreateChooser(intent, title);
            chooser.SetFlags(ActivityFlags.GrantReadUriPermission);

            Android.App.Application.Context.StartActivity(chooser);

            return Task.FromResult(true);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PersonalExpenses.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ProgressBar), typeof(CustomProgressBarRenderer))]
namespace PersonalExpenses.Droid.CustomRenderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {        
        public CustomProgressBarRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);
            if (double.IsNaN(e.NewElement.Progress))
                Control.ProgressDrawable.SetTint(Color.Red.ToAndroid());
            else
                if (e.NewElement.Progress <= 0.2)
                Control.ProgressDrawable.SetTint(Color.LightGray.ToAndroid());
            else
                if (e.NewElement.Progress <= 0.4)
                Control.ProgressDrawable.SetTint(Color.LightGreen.ToAndroid());
            else
                if (e.NewElement.Progress <= 0.6)
                Control.ProgressDrawable.SetTint(Color.LightBlue.ToAndroid());
            else
                if (e.NewElement.Progress <= 0.8)
                Control.ProgressDrawable.SetTint(Color.DarkGray.ToAndroid());
            else
                Control.ProgressDrawable.SetTint(Color.Orange.ToAndroid());
            Control.ScaleX = 2.0f;
        }
    }
}
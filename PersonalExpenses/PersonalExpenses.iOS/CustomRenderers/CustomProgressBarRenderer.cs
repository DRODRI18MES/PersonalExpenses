using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using PersonalExpenses.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(ProgressBarRenderer))]
namespace PersonalExpenses.iOS.CustomRenderers
{    
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);
            if (double.IsNaN(e.NewElement.Progress))
                Control.ProgressTintColor = Color.Red.ToUIColor();
                else
                    if (e.NewElement.Progress <= 0.2)
                        Control.ProgressTintColor = Color.LightGray.ToUIColor(); 
                    else
                        if (e.NewElement.Progress <= 0.4)
                            Control.ProgressTintColor = Color.Gray.ToUIColor();
                        else
                            if (e.NewElement.Progress <= 0.6)
                                Control.ProgressTintColor = Color.SlateGray.ToUIColor();
                            else
                                if (e.NewElement.Progress <= 0.8)
                                    Control.ProgressTintColor = Color.DarkGray.ToUIColor();
                                else
                                    Control.ProgressTintColor = Color.Black.ToUIColor();
            LayoutSubviews();
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            float scaleX = 1.0f;
            float scaleY = 4.0f;
            var transform = CGAffineTransform.MakeScale(scaleX, scaleY);
            Transform = transform;
        }
    }
}
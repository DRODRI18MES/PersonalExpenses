using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PersonalExpenses.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]
[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]
namespace PersonalExpenses.Droid.CustomRenderers
{    
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        private Android.Views.View _cell;
        private Drawable _normalBackground;
        private bool _isSelected;

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);
            var cell = sender as ViewCell;
            if(e.PropertyName== "IsSelected")
            {
                _isSelected = !_isSelected;
                if (_isSelected)
                {
                    switch (cell.StyleId)
                    {
                        case "blue":
                            _cell.SetBackgroundColor(Android.Graphics.Color.DodgerBlue);
                            break;
                        case "red":
                            _cell.SetBackgroundColor(Android.Graphics.Color.Red);
                            break;
                        case "transparent":
                            _cell.SetBackgroundColor(Android.Graphics.Color.Transparent);
                            break;
                        default:
                            _cell.SetBackgroundColor(Android.Graphics.Color.LightBlue);
                            break;
                    }
                }
                else
                    _cell.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            _cell = base.GetCellCore(item, convertView, parent, context);

            _normalBackground = _cell.Background;
            _isSelected = false;

            return _cell;
        }
    }

    public class CustomTextCellRenderer : TextCellRenderer
    {
        private Android.Views.View _cell;
        private Drawable _normalBackground;
        private bool _isSelected;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            _cell = base.GetCellCore(item, convertView, parent, context);

            _normalBackground = _cell.Background;
            _isSelected = false;

            return _cell;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);
            var cell = sender as TextCell;
            if (e.PropertyName == "IsSelected")
            {
                _isSelected = !_isSelected;
                if (_isSelected)
                {
                    switch (cell.StyleId)
                    {
                        case "blue":
                            _cell.SetBackgroundColor(Android.Graphics.Color.DodgerBlue);
                            break;
                        case "red":
                            _cell.SetBackgroundColor(Android.Graphics.Color.Red);
                            break;
                        case "transparent":
                            _cell.SetBackgroundColor(Android.Graphics.Color.Transparent);
                            break;
                        default:
                            _cell.SetBackgroundColor(Android.Graphics.Color.LightBlue);
                            break;
                    }
                }
                else
                    _cell.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using PersonalExpenses.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]
namespace PersonalExpenses.iOS.CustomRenderers
{
    public class CustomTextCellRenderer : TextCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);

            switch(item.StyleId)
            {
                case "none":
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;
                case "checkmark":
                    cell.Accessory = UITableViewCellAccessory.Checkmark;
                    break;
                case "detailbutton":
                    cell.Accessory = UITableViewCellAccessory.DetailButton;
                    break;
                case "detail-disclosure-button":
                    cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
                    break;
                case "disclosure-indicator":
                default:
                    cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                    break;
            }

            return cell;
        }
    }
}
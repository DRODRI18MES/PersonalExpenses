using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using PersonalExpenses.iOS.Dependencies;
using PersonalExpenses.ViewModel.Interfaces;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace PersonalExpenses.iOS.Dependencies
{
    public class Share : IShare
    {
        public async Task Show(string title, string message, string path)
        {
            var viewController = GetVisibleViewController();
            var items = new NSObject[] { NSObject.FromObject(title), NSUrl.FromFilename(path), NSString.FromObject(message) };

            var activityController = new UIActivityViewController(items, null);

            if (activityController.PopoverPresentationController != null)
                activityController.PopoverPresentationController.SourceView = viewController.View;

            await viewController.PresentViewControllerAsync(activityController, true);

            //return Task.FromResult(true);
        }

        private UIViewController GetVisibleViewController()
        {
            var rootViewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            if (rootViewController.PresentedViewController == null)
                return rootViewController;

            if (rootViewController.PresentedViewController == null)
                return rootViewController;
            if (rootViewController.PresentedViewController is UINavigationController)
                return ((UINavigationController)rootViewController.PresentedViewController);

            if (rootViewController.PresentedViewController is UITabBarController)
                return ((UITabBarController)rootViewController.PresentedViewController);

            return null;
        }
    }
}
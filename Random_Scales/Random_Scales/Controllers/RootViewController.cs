using System;

using CoreGraphics;
using Foundation;
using UIKit;

namespace App2
{
	public partial class RootViewController : UIViewController
	{
		public ModelController ModelController {
			get;
			private set;
		}

		public UIPageViewController PageViewController {
			get;
			private set;
		}

		protected RootViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			ModelController = new ModelController ();

			// Configure the page view controller and add it as a child view controller.
			PageViewController = new UIPageViewController (UIPageViewControllerTransitionStyle.PageCurl, UIPageViewControllerNavigationOrientation.Horizontal, UIPageViewControllerSpineLocation.Min);
			PageViewController.WeakDelegate = this;

			var startingViewController = ModelController.GetViewController (0, Storyboard);
			var viewControllers = new UIViewController[] { startingViewController };
			PageViewController.SetViewControllers (viewControllers, UIPageViewControllerNavigationDirection.Forward, false, null);

			PageViewController.WeakDataSource = ModelController;

			AddChildViewController (PageViewController);
			View.AddSubview (PageViewController.View);

			// Set the page view controller's bounds using an inset rect so that self's view is visible around the edges of the pages.
			var pageViewRect = View.Bounds;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				pageViewRect = new CGRect (pageViewRect.X + 20, pageViewRect.Y + 20, pageViewRect.Width - 40, pageViewRect.Height - 40);
			PageViewController.View.Frame = pageViewRect;

			PageViewController.DidMoveToParentViewController (this);

			// Add the page view controller's gesture recognizers to the book view controller's view so that the gestures are started more easily.
			View.GestureRecognizers = PageViewController.GestureRecognizers;
		}

		[Export ("pageViewController:spineLocationForInterfaceOrientation:")]
		public UIPageViewControllerSpineLocation GetSpineLocation (UIPageViewController pageViewController, UIInterfaceOrientation orientation)
		{
			UIViewController currentViewController;
			UIViewController[] viewControllers;

			if (orientation == UIInterfaceOrientation.Portrait || orientation == UIInterfaceOrientation.PortraitUpsideDown || UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
				// In portrait orientation or on iPhone: Set the spine position to "min" and the page view controller's view controllers array to contain just one view controller.
				// Setting the spine position to 'UIPageViewControllerSpineLocation.Mid' in landscape orientation sets the doubleSided property to true, so set it to false here.
				currentViewController = pageViewController.ViewControllers [0];
				viewControllers = new [] { currentViewController };
				pageViewController.SetViewControllers (viewControllers, UIPageViewControllerNavigationDirection.Forward, true, null);

				pageViewController.DoubleSided = false;

				return UIPageViewControllerSpineLocation.Min;
			}

			// In landscape orientation: Set set the spine location to "mid" and the page view controller's view controllers array to contain two view controllers.
			// If the current page is even, set it to contain the current and next view controllers; if it is odd, set the array to contain the previous and current view controllers.
			currentViewController = pageViewController.ViewControllers [0];

			int index = ModelController.IndexOf ((DataViewController)currentViewController);
			if (index == 0 || index % 2 == 0) {
				var nextViewController = ModelController.GetNextViewController (pageViewController, currentViewController);
				viewControllers = new [] { currentViewController, nextViewController };
			} else {
				var previousViewController = ModelController.GetPreviousViewController (pageViewController, currentViewController);
				viewControllers = new [] { previousViewController, currentViewController };
			}

			pageViewController.SetViewControllers (viewControllers, UIPageViewControllerNavigationDirection.Forward, true, null);

			return UIPageViewControllerSpineLocation.Mid;
		}
	}
}


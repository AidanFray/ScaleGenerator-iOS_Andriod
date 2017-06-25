using System;
using UIKit;

namespace ScalesApp
{
	public partial class DataViewController : UIViewController
	{
		public string DataObject {
			get;
			set;
		}

		protected DataViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            
            
        }


		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
            
        }


        
    }
}


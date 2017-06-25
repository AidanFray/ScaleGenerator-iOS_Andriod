using Foundation;
using System;
using UIKit;
using ScalesApp.Shared;

namespace ScalesApp
{
    public partial class MainView : UIViewController
    {
        UIViewController ScaleRandomisePage;
       
        public MainView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ScaleRandomisePage = Storyboard.InstantiateViewController("scalePage") as scalePage;
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            
            Settings.LoadSettings();
            
        }
        
        partial void ScalesButton_TouchUpInside(UIButton sender)
        {
            NavigationController.PushViewController(ScaleRandomisePage, true);
        }

        partial void UIButton2315_TouchUpInside(UIButton sender)
        {
            
        }
    }
}
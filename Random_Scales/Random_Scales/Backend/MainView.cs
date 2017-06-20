using Foundation;
using System;
using UIKit;

namespace App2
{
    public partial class MainView : UIViewController
    {
        UIViewController ScaleRandomisePage;
        UIViewController SettingPage;

        public MainView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            ScaleRandomisePage = Storyboard.InstantiateViewController("scalePage") as scalePage;
            SettingPage = Storyboard.InstantiateViewController("settingPage") as settingPage;
        }

        partial void ScalesButton_TouchUpInside(UIButton sender)
        {
            NavigationController.PushViewController(ScaleRandomisePage, true);
        }

        partial void UIButton2315_TouchUpInside(UIButton sender)
        {
            NavigationController.PushViewController(SettingPage, true);
        }
    }
}
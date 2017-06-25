using Foundation;
using ScalesApp.Shared;
using System;
using UIKit;

namespace ScalesApp
{
    public partial class settingPage : UITabBarController
    {
        public settingPage(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UIBarButtonItem button = new UIBarButtonItem()
            {
                Title = "Reset All",
                Enabled = true
            };
            button.Clicked += HandleTouchUpInside;

            this.NavigationItem.SetRightBarButtonItem(button, false);

        }

        void HandleTouchUpInside(object sender, EventArgs ea)
        {
            Settings.ResetAll();
        }
    }
}
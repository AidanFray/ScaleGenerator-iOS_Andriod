using Foundation;
using ScalesApp.Shared;
using System;
using UIKit;

namespace ScalesApp
{
    public partial class settingPage : UITabBarController
    {
        public settingPage(IntPtr handle) : base(handle) {}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Create_ResetButton();
        }

        void Create_ResetButton()
        {
            UIBarButtonItem button = new UIBarButtonItem()
            {
                Title = "Reset All",
                Enabled = true
            };
            button.Clicked += HandleTouchUpInside;

            NavigationItem.SetRightBarButtonItem(button, false);
        }

        //Reset_Button TouchUpInside Handle
        void HandleTouchUpInside(object sender, EventArgs ea)
        {
            Settings.ResetAll();
        }

        void OnSizeChanged(object sender, EventArgs e)
        {

        }
    }
}
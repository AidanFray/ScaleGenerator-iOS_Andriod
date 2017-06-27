using ScalesApp.Shared;
using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using System.Threading;

namespace ScalesApp
{
    public partial class ModesTabPage : UIViewController
    {
        //Class that deals with creating page settings
        public static SettingPage Page;

        public ModesTabPage(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Page = new SettingPage(View, Settings.modes, "modes");
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            Page.WhenViewAppears();
        }
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            Page.WhenViewDisappears();
        }
        public override void WillAnimateRotation(UIInterfaceOrientation toInterfaceOrientation, double duration)
        {
            base.WillAnimateRotation(toInterfaceOrientation, duration);

            Page.Screen_Rotate(toInterfaceOrientation);
        }
    }
}
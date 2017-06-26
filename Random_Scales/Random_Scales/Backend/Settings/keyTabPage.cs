using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using ScalesApp.Shared;
using System.Threading;

namespace ScalesApp
{
    public partial class KeyTabPage : UIViewController
    {
        //Class that deals with creating page settings
        public static SettingPage Page;

        public KeyTabPage(IntPtr handle) : base(handle)
        {
            
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Page init has to be here because View in the constructor is different to the view here
            //That is not the case with the other pages
            //Possibly becuase this is the first page?
            Page = new SettingPage(View, Settings.keys, "keys");
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
    }
}
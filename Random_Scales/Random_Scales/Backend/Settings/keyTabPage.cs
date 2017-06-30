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
            Page = new SettingPage(View, this, Settings_iOS.keys, "keys");
            
            //If the page is entered when Landscape
            Page.Screen_Rotate(UIApplication.SharedApplication.StatusBarOrientation);
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

        public void Display()
        {
            //Create Alert
            var okAlertController = UIAlertController.Create("OK Alert", "This is a sample alert with an OK button.", UIAlertControllerStyle.Alert);

            //Add Action
            okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            // Present Alert
            PresentViewController(okAlertController, true, null);
        }
    }
}
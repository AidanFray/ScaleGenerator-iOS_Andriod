// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ScalesApp
{
    [Register ("MainView")]
    partial class MainView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView mainView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton scalesButton { get; set; }

        [Action ("ScalesButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ScalesButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("UIButton2315_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton2315_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (mainView != null) {
                mainView.Dispose ();
                mainView = null;
            }

            if (scalesButton != null) {
                scalesButton.Dispose ();
                scalesButton = null;
            }
        }
    }
}
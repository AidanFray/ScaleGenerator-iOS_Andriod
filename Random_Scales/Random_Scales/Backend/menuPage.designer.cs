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
        UIKit.UIImageView AppLogo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView AppLogoRotated { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView mainView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem menuBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton scalesButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton scalesButtonRotated { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton settingButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton settingButtonRotated { get; set; }

        [Action ("ScalesButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ScalesButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("SettingButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SettingButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AppLogo != null) {
                AppLogo.Dispose ();
                AppLogo = null;
            }

            if (AppLogoRotated != null) {
                AppLogoRotated.Dispose ();
                AppLogoRotated = null;
            }

            if (mainView != null) {
                mainView.Dispose ();
                mainView = null;
            }

            if (menuBar != null) {
                menuBar.Dispose ();
                menuBar = null;
            }

            if (scalesButton != null) {
                scalesButton.Dispose ();
                scalesButton = null;
            }

            if (scalesButtonRotated != null) {
                scalesButtonRotated.Dispose ();
                scalesButtonRotated = null;
            }

            if (settingButton != null) {
                settingButton.Dispose ();
                settingButton = null;
            }

            if (settingButtonRotated != null) {
                settingButtonRotated.Dispose ();
                settingButtonRotated = null;
            }
        }
    }
}
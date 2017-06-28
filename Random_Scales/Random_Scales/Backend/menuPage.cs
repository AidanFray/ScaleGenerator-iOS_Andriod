using Foundation;
using System;
using UIKit;
using ScalesApp.Shared;
using CoreGraphics;

namespace ScalesApp
{
    public partial class MainView : UIViewController
    {
        UIViewController ScaleRandomisePage;

        public MainView(IntPtr handle) : base(handle)
        {
            //Checks if this has been run before
            if (!Settings.LoadFirstSetupState())
            {
                Settings.Initial_Setup();
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Orientation();
            ScaleRandomisePage = Storyboard.InstantiateViewController("scalePage") as scalePage;
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            Orientation();
            Settings.LoadSettings();
        }
        partial void ScalesButton_TouchUpInside(UIButton sender)
        {
            NavigationController.PushViewController(ScaleRandomisePage, true);
        }
        partial void SettingButton_TouchUpInside(UIButton sender)
        {

        }

        //Code used to adapt controls for different screens

        nfloat _screenW;
        nfloat _screenH;
        private void Orientation()
        {
            var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;

            //Makes sure the correct setup
            if (currentOrientation == UIInterfaceOrientation.Portrait)
            {
                DynamicallyPositionItemsPortrait();
            }
            else
            {
                DynamicallyPositionItemsLandscape();
            }
        }
        private void DynamicallyPositionItemsPortrait()
        {
            //Grabs screen size
            _screenW = View.Frame.Width;
            _screenH = View.Frame.Height;

            //Moves logo
            AppLogo.Frame = CenterControlX(190, 190, 90);

            //Moves buttons
            scalesButton.Frame = CenterControlX(200, 100, (int)_screenH - 300);
            settingButton.Frame = CenterControlX(200, 100, (int)_screenH - 150);

        }
        private void DynamicallyPositionItemsLandscape()
        {
            //---------Landscape--------------
            //Grabs screen size
            _screenW = View.Frame.Width;
            _screenH = View.Frame.Height;

            //Moves logo
            AppLogoRotated.Frame = CenterControlY(200, 200, 50);

            //Moves buttons
            CGRect rect = CenterControlY(200, 100, _screenW - 300);
            rect.Y -= 70;
            scalesButtonRotated.Frame = rect;

            rect = CenterControlY(200, 100, _screenW - 300);
            rect.Y += 70;
            settingButtonRotated.Frame = rect;
        }
        private CGRect CenterControlX(nfloat w, nfloat h, nfloat startY)
        {
            return new CGRect((_screenW / 2) - (w / 2), startY, w, h);
        }
        private CGRect CenterControlY(nfloat w, nfloat h, nfloat startX)
        {
            return new CGRect(startX, (_screenH / 2) - (h / 2), w, h);
        }
        public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
        {
            base.DidRotate(fromInterfaceOrientation);

            if (UIInterfaceOrientation.Portrait == fromInterfaceOrientation)
            {
                DynamicallyPositionItemsLandscape();
            }
            else
            {
                DynamicallyPositionItemsPortrait();
            }
        }
    }
}

using Foundation;
using System;
using UIKit;
using ScalesApp.Shared;
using System.Collections.Generic;
using CoreGraphics;
using Scales.Core;
using static ScalesApp.Shared.Settings_iOS;

namespace ScalesApp
{
    public partial class scalePage : UIViewController
    {
        public scalePage(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            AllowTouch();

            Orientation();
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            SettingiOS.ApplySettings();
            SettingiOS.SetupScaleShuffle();
            Rnd_ScaleChange();
        }

        //Changes on touch
        private void AllowTouch()
        {
            //Allows touch interaction
            scaleText.UserInteractionEnabled = true;
            UITapGestureRecognizer tap = new UITapGestureRecognizer(Rnd_ScaleChange);
            scaleView.AddGestureRecognizer(tap);
        }
        private void Rnd_ScaleChange()
        {
            //Checks if the pools need a refresh
            if (!SettingiOS.PoolEmpty())
            {
                //Grabs the next key and mode
                scaleText.Text = SettingiOS.NextKey();
                modeText.Text = SettingiOS.NextMode();
                scaleTextRotated.Text = SettingiOS.NextKey();
                modeTextRotated.Text = SettingiOS.NextMode();

                //Moves along to the next index
                SettingiOS.increment_positionInCurrentPool();
            }
            else
            {
                SettingiOS.SetupScaleShuffle();
            }

            //Updates the scale image
            ChangeScaleImage();

        }
        private void ChangeScaleImage()
        {
            var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;

            if (modeText.Text == "Super-Locrian (Alt)")
            {
                ScalePhoto.Image = UIImage.FromBundle($"{scaleText.Text}_Super_Locrian");
            }
            else
            {
                ScalePhoto.Image = UIImage.FromBundle($"{scaleText.Text}_{modeText.Text}");

            }
            ScalePhotoRotated.Image = ScalePhoto.Image;
        }

        partial void ExpandButton_TouchUpInside(UIButton sender)
        {
            //Toggles scale image
            if (ScalePhoto.Hidden)
            {
                ScalePhoto.Hidden = false;
                ChangeScaleImage();
            }
            else
            {
                ScalePhoto.Hidden = true;
            }
        }

        //==============================TODO: TURN INTO GENERAL CLASS =========================================
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
            //--------Portrait-----------
            //Grabs screen size
            _screenW = View.Frame.Width;
            _screenH = View.Frame.Height;

            //Moves text
            scaleText.Frame = CenterControl(200, 100, 200);
            modeText.Frame = CenterControl(400, 50, 330);

            //Moves photo
            ScalePhoto.Frame = CenterControl((_screenW - 10), (_screenW - 10) * (nfloat)0.1134, 450);

            //Moves buttons
            ExpandButton.Frame = CenterControl(_screenW, 100, _screenH - 100);

        }
        private void DynamicallyPositionItemsLandscape()
        {
            //---------Landscape--------------
            //Grabs screen size
            _screenW = View.Frame.Width;
            _screenH = View.Frame.Height;

            //Moves text
            scaleTextRotated.Frame = CenterControl(_screenW, 50, 100);
            modeTextRotated.Frame = CenterControl(_screenW, 50, 150);

            //Moves photo
            ScalePhotoRotated.Frame = CenterControl((_screenW - 5), (_screenW - 5) * (nfloat)0.1134, _screenH - 120);
        }
        private CGRect CenterControl(nfloat w, nfloat h, nfloat startY)
        {
            return new CGRect((_screenW / 2) - (w / 2), startY, w, h);
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
        //=====================================================================================================
    }
}
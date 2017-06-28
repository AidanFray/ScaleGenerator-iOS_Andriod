using Foundation;
using System;
using UIKit;
using ScalesApp.Shared;
using System.Collections.Generic;
using CoreGraphics;

namespace ScalesApp
{
    public partial class scalePage : UIViewController
    {
        //Possible values defined in the settings
        private List<string> _keyPool = new List<string>();
        private List<string> _modePool = new List<string>();

        //Used to prevent repeats
        private int _positionInCurrentPool;
        private List<Scale> _currentScalePool = new List<Scale>();

        private Random _random = new Random();

        public scalePage(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Orientation();

            //Allows touch interaction
            scaleText.UserInteractionEnabled = true;
            UITapGestureRecognizer tap = new UITapGestureRecognizer(Rnd_ScaleChange);
            scaleView.AddGestureRecognizer(tap);
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            ApplySettings();

            SetupScaleShuffle();
        }

        private void ApplySettings()
        {
            _keyPool.Clear();
            for (int i = 0; i < Settings.activeKeys.Count; i++)
            {
                if (Settings.activeKeys[i])
                {
                    //Adds scales to the pool
                    _keyPool.Add(Settings.keys[i]);
                }
            }

            _modePool.Clear();
            for (int i = 0; i < Settings.activeModes.Count; i++)
            {
                if (Settings.activeModes[i])
                {
                    //Adds scales to the pool
                    _modePool.Add(Settings.modes[i]);
                }
            }
        }
        private void Rnd_ScaleChange()
        {
            //Checks if the pools need a refresh
            if (!PoolEmpty())
            {
                scaleText.Text = _currentScalePool[_positionInCurrentPool].get_key();
                modeText.Text = _currentScalePool[_positionInCurrentPool].get_mode();

                scaleTextRotated.Text = _currentScalePool[_positionInCurrentPool].get_key();
                modeTextRotated.Text = _currentScalePool[_positionInCurrentPool].get_mode();

                _positionInCurrentPool++;
            }
            else
            {
                SetupScaleShuffle();
            }

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
        private bool PoolEmpty()
        {
            //Checks if both lists are empty
            if (_currentScalePool.Count == 0)
            {
                return true;
            }
            else
            {
                if (_positionInCurrentPool > _currentScalePool.Count - 1)
                {
                    return true;
                }
            }

            return false;
        }
        private void SetupScaleShuffle()
        {
            //Reset
            _currentScalePool.Clear();

            //Position in the random list
            _positionInCurrentPool = 0;


            //This creates a comprehenisive list of all the scale combinations
            foreach (string key in _keyPool)
            {
                foreach (string mode in _modePool)
                {
                    Scale newScale = new Scale(key, mode);
                    _currentScalePool.Add(newScale);
                }
            }

            //The comprehensive list is then shuffeled
            _currentScalePool = Shuffle(_currentScalePool);

            //Random scale selected
            Rnd_ScaleChange();
        }
        private List<Scale> Shuffle(List<Scale> listToShuffle)
        {
            //Fisher-Yates Shuffle

            //Copys list to a temp var
            List<Scale> temp = new List<Scale>(listToShuffle);

            for (int index = temp.Count - 1; index > 0; index--)
            {
                //Gets a new index
                int rndIndex = _random.Next(0, index);

                //Swap
                Scale buffer = temp[index];
                temp[index] = temp[rndIndex];
                temp[rndIndex] = buffer;
            }
            return temp;
        }

        partial void ExpandButton_TouchUpInside(UIButton sender)
        {
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
    }
}
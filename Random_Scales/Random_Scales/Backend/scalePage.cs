using Foundation;
using System;
using UIKit;
using ScalesApp.Shared;
using System.Collections.Generic;


namespace ScalesApp
{
    public partial class scalePage : UIViewController
    {
        //Possible values defined in the settings
        List<string> keyPool = new List<string>();
        List<string> modePool = new List<string>();

        //Used to prevent repeats
        private int _positionInCurrentPool;
        private List<Scale> _currentScalePool = new List<Scale>();

        Random random = new Random();

        public scalePage(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Allows touch interaction
            scaleText.UserInteractionEnabled = true;
            UITapGestureRecognizer tap = new UITapGestureRecognizer(Rnd_ScaleChange);
            scaleView.AddGestureRecognizer(tap);

            UIBarButtonItem button = new UIBarButtonItem()
            {
                Title = "Hello",
                Enabled = true
            };
            //button.Clicked += HandleTouchUpInside;

            NavigationItem.SetRightBarButtonItem(button, false);

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            ApplySettings();

            SetupScaleShuffle();
        }

        public void ApplySettings()
        {
            keyPool.Clear();
            for (int i = 0; i < Settings.activeScales.Count; i++)
            {
                if (Settings.activeScales[i])
                {
                    //Adds scales to the pool
                    keyPool.Add(Settings.scales[i]);
                }
            }

            modePool.Clear();
            for (int i = 0; i < Settings.activeModes.Count; i++)
            {
                if (Settings.activeModes[i])
                {
                    //Adds scales to the pool
                    modePool.Add(Settings.modes[i]);
                }
            }
        }

        public void Rnd_ScaleChange()
        {
            //Checks if the pools need a refresh
            if (!PoolEmpty())
            {
                scaleText.Text = _currentScalePool[_positionInCurrentPool].get_key();
                modeText.Text = _currentScalePool[_positionInCurrentPool].get_mode();

                _positionInCurrentPool++;
            }
            else
            {
                SetupScaleShuffle();
            }
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

        //Fisher-Yates Shuffle
        //TODO: REVIEW: System.Random is fast but not very random
        //Possible use of System.Security.Cryptography
        private void SetupScaleShuffle()
        {
            //Reset
            _currentScalePool.Clear(); 

            _positionInCurrentPool = 0;

            foreach (string key in keyPool)
            {
                foreach (string mode in modePool)
                {
                    Scale newScale = new Scale(key, mode);
                    _currentScalePool.Add(newScale);
                }
            }

            _currentScalePool = Shuffle(_currentScalePool);

            Rnd_ScaleChange();
        }

        private List<Scale> Shuffle(List<Scale> listToShuffle)
        {
            //Copys list to a temp var
            List<Scale> temp = new List<Scale>(listToShuffle);

            for (int index = temp.Count - 1; index > 0; index--)
            {
                //Gets a new index
                int rndIndex = random.Next(0, index);

                //Swap
                Scale buffer = temp[index];
                temp[index] = temp[rndIndex];
                temp[rndIndex] = buffer;
            }
            return temp;
        }
    }

    public class Scale
    {
        public Scale(string key, string mode)
        {
            _key = key;
            _mode = mode;
        }

        private string _key;
        private string _mode;

        public string get_key()
        {
            return _key;
        }
        public string get_mode()
        {
            return _mode;
        }

    }
}
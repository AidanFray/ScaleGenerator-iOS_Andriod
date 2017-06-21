using Foundation;
using System;
using UIKit;
using App2.Shared;
using System.Collections.Generic;

namespace App2
{
    public partial class scalePage : UIViewController
    {
        public scalePage (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ApplySettings();

            //Allows touch interaction
            scaleText.UserInteractionEnabled = true;
            UITapGestureRecognizer tap = new UITapGestureRecognizer(Rnd_ScaleChange);
            scaleView.AddGestureRecognizer(tap);
            
            //Randomises the label
            Rnd_ScaleChange();
        }
        
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            ApplySettings();

        }

        //TODO: Refactor
        public void ApplySettings()
        {
            scalePool.Clear();
            for (int i = 0; i < Settings.activeScales.Count; i++)
            {
                if (Settings.activeScales[i])
                {
                    //Adds scales to the pool
                    scalePool.Add(Settings.scales[i]);
                }
            }

            modePool.Clear();
            for(int i = 0; i < Settings.activeModes.Count; i++)
            {
                if (Settings.activeModes[i])
                {
                    //Adds scales to the pool
                    modePool.Add(Settings.modes[i]);
                }
            }
        }

        //TODO: REFACTOR
        Random r = new Random();
        List<string> scalePool = new List<string>();
        List<string> modePool = new List<string>();
        public void Rnd_ScaleChange()
        {
            int newScale = r.Next(0, scalePool.Count);
            scaleText.Text = scalePool[newScale];

            int newMode = r.Next(0, modePool.Count);
            modeText.Text = modePool[newMode];
        }
    }
}
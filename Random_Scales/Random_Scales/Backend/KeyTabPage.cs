﻿using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using App2.Shared;

namespace App2
{
    public partial class KeyTabPage : UIViewController
    {
        public KeyTabPage(IntPtr handle) : base(handle) { }
        
        //List of switches
        public List<UISwitch> switches = new List<UISwitch>();

        UIScrollView sview;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Creates pre defined layout
            Create_Controls();

            View.AddSubview(sview);
        }
        
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            Load_Switches();
        }
        
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            Save_Switches();
        }

        private void Create_Controls()
        {
            sview = new UIScrollView()
            {
                Frame = new CGRect(0, 0, View.Frame.Width, View.Frame.Height),
                ContentSize = new CGSize(View.Frame.Width, (Settings.scales.Length * spacing) + 100),
                ScrollEnabled = true
            };

            for (int i = 0; i < Settings.scales.Length; i++)
            {
                AddControls(Settings.scales[i]);
            }
        }

        int position = 60;
        int spacing = 50;
        bool alternate = false;
        public void AddControls(string txt)
        {

            UILabel label = new UILabel()
            {
                Text = txt,
                Frame = new CoreGraphics.CGRect(10, position, View.Frame.Width, spacing),
                Hidden = false
            };

            if (alternate)
            {
                label.BackgroundColor = UIColor.FromRGB(252, 237, 237);

            }
            else
            {
                label.BackgroundColor = UIColor.White;
            }
            alternate = !alternate;

            UISwitch swi = new UISwitch
            {
                Frame = new CGRect(View.Frame.Width - 70, position + 10, 50, 50)
            };
            switches.Add(swi);

            sview.AddSubview(label);
            sview.AddSubview(swi);

            position += spacing;
        }

        private void Load_Switches()
        {
            //Loads states
            for (int i = 0; i < switches.Count; i++)
            {
                switches[i] = Settings.LoadSwitchState(switches[i], "keys", i);
            }
        }
        private void Save_Switches()
        {
            //Saves all the switch states
            for (int i = 0; i < switches.Count; i++)
            {
                Settings.SaveSwitchState(switches[i], "keys", i);
            }
        }
    }
}
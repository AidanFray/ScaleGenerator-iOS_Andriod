using ScalesApp.Shared;
using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
namespace ScalesApp
{
    public partial class ModesTabPage : UIViewController
    {
        public ModesTabPage (IntPtr handle) : base (handle)
        {
        }

        //List of switches
        public static List<UISwitch> switches = new List<UISwitch>();
        
        UIScrollView sview;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
        
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            //Resets
            switches.Clear();

            //Creates pre defined layout
            Create_Controls();
            View.AddSubview(sview);
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
                ContentSize = new CGSize(View.Frame.Width, (Settings.modes.Length * spacing) + 100),
                ScrollEnabled = true
            };

            for (int i = 0; i < Settings.modes.Length; i++)
            {
                AddControls(Settings.modes[i]);
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
                switches[i] = Settings.LoadSwitchState(switches[i], "modes", i);
            }
        }
        private void Save_Switches()
        {
            //Saves all the switch states
            for (int i = 0; i < switches.Count; i++)
            {
                Settings.SaveSwitchState(switches[i], "modes", i);
            }
        }
    }
}
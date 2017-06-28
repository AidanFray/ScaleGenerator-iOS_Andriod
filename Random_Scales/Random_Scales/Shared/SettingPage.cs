using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using ScalesApp.Shared;

namespace ScalesApp.Shared
{
    //Generic class used to create a setting page
    public class SettingPage
    {
        public SettingPage(UIView PageView, UIViewController vController, string[] MenuItems, string SaveID)
        {
            _view = PageView;
            _menuItems = MenuItems;
            _savingID = SaveID;
            _viewController = vController;
        }

        public List<UISwitch> PageSwitches = new List<UISwitch>(); //List of switches

        private UIView _view;
        private UIViewController _viewController;
        private UIScrollView _scrollView;
        private string[] _menuItems;
        private string _savingID;
        public static int _settingsStartPosition = 60;
        private int _position;
        private int _spacing = 50;
        private bool _alternate = false;

        public void WhenViewAppears()
        {
            Create_Controls();

            Load_Switches();
        }
        public void WhenViewDisappears()
        {
            Save_Switches();
        }

        public void Create_Controls()
        {
            //Refreshes to fix rotation problems
            if (_view.Subviews.Contains(_scrollView))
            {
                Remove_Controls();
            }

            _position = _settingsStartPosition;

            PageSwitches.Clear();
            //Creates the Scroll View
            _scrollView = new UIScrollView()
            {
                Frame = new CGRect(0, 0, _view.Frame.Width, _view.Frame.Height),
                ContentSize = new CGSize(_view.Frame.Width, (_menuItems.Length * _spacing) + 100),
                ScrollEnabled = true
            };

            //Dynamically adds labels and switches
            for (int i = 0; i < _menuItems.Length; i++)
            {
                AddControls(_menuItems[i]);
            }
            _view.AddSubview(_scrollView);
            _position = _settingsStartPosition;
        }
        private void AddControls(string txt)
        {
            //Creates a label
            UILabel label = new UILabel()
            {
                Text = txt,
                Frame = new CoreGraphics.CGRect(5, _position, _view.Frame.Width, _spacing),
                Hidden = false
            };

            //Alternates colour for background
            if (_alternate)
            {
                //TODO: Turn colour into var
                label.BackgroundColor = UIColor.FromRGB(252, 237, 237);
            }
            else
            {
                label.BackgroundColor = UIColor.White;
            }
            _alternate = !_alternate;

            //Creates switch
            UISwitch swi = new UISwitch
            {
                Frame = new CGRect(_view.Frame.Width - 70, _position + 10, 50, 50)
            };
            swi.ValueChanged += SwitchToggled;

            //Adds controls to relevent locations
            PageSwitches.Add(swi);
            _scrollView.AddSubview(label);
            _scrollView.AddSubview(swi);

            //Moves down
            _position += _spacing;
        }

        //Used to load and save the states of the switches
        public void Load_Switches()
        {
            //Loads states
            for (int i = 0; i < PageSwitches.Count; i++)
            {
                PageSwitches[i] = Settings.LoadSwitchState(PageSwitches[i], _savingID, i);
            }
        }
        public void Save_Switches()
        {
            //Saves all the switch states
            for (int i = 0; i < PageSwitches.Count; i++)
            {
                Settings.SaveSwitchState(PageSwitches[i], _savingID, i);
            }
        }

        //Used to remove the scroll view
        public void Remove_Controls()
        {
            foreach (UIView sV in _view.Subviews)
            {
                if (sV is UIScrollView)
                {
                    sV.RemoveFromSuperview();
                }
                else //HACK: Reset Button I can't find and delete
                {
                    if (sV is UIButton)
                    {
                        UIButton b = (UIButton)sV;
                        b.Hidden = true;
                    }
                }
            }
        }

        //Event fired when the screen rotates
        public void Screen_Rotate(UIInterfaceOrientation toInterfaceOrientation)
        {
            Save_Switches();

            Remove_Controls();
            if (toInterfaceOrientation == UIInterfaceOrientation.LandscapeLeft ||
                toInterfaceOrientation == UIInterfaceOrientation.LandscapeLeft)
            {
                _settingsStartPosition = 30;
            }
            else
            {
                _settingsStartPosition = 60;
            };
            WhenViewAppears();
        }

        void SwitchToggled(object sender, EventArgs e)
        {
            //The calling switch
            UISwitch _triggeredSwitch = (UISwitch)sender;

            //Keep track of how many 
            int _onCount = 0;

            //Checks if the last toggle on the page has been triggered
            foreach (UISwitch _switch in PageSwitches)
            {
                if (_switch != _triggeredSwitch)
                {
                    //If there're more than on active switches
                    if (_onCount > 1)
                    {
                        break;
                    }
                    else
                    {
                        //If the switch is active
                        if (_switch.On)
                        {
                            _onCount++;
                        }
                    }
                }
            }

            //If there are no other switches on
            if (_onCount == 0)
            {
                DisplayAlert();

                //Reverts selection
                _triggeredSwitch.SetState(true, true);
            }
        }
        void DisplayAlert()
        {
            //Create Alert
            var okAlertController = UIAlertController.Create("Error", "You cannot deselect all options", UIAlertControllerStyle.Alert);

            //Add Action
            okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            // Present Alert
            _viewController.PresentViewController(okAlertController, true, null);
        }
    }
}
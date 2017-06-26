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
        public SettingPage(UIView PageView, string[] MenuItems, string SaveID)
        {
            _view = PageView;
            _menuItems = MenuItems;
            _savingID = SaveID;
        }

        public List<UISwitch> PageSwitches = new List<UISwitch>(); //List of switches
        
        public UIView _view;
        private UIScrollView _scrollView;
        private string[] _menuItems;
        private string _savingID;
        private const int _settingsStartPosition = 60;
        private int _position = _settingsStartPosition;
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
            //Checks to see if a subview has been added
            if (!_view.Subviews.Contains(_scrollView))
            {
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

        }
        private void AddControls(string txt)
        {
            //Creates a label
            UILabel label = new UILabel()
            {
                Text = txt,
                Frame = new CoreGraphics.CGRect(10, _position, _view.Frame.Width, _spacing),
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

            //Adds controls to relevent locations
            PageSwitches.Add(swi);
            _scrollView.AddSubview(label);
            _scrollView.AddSubview(swi);

            //Moves down
            _position += _spacing;
        }

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
    }
}
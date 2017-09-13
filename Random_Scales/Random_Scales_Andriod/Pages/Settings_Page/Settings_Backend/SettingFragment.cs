using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Preferences;
using Random_Scales_Andriod.Resources.settings;

namespace Random_Scales_Andriod.Resources.preferences
{
    public class SettingFragment : PreferenceFragment
    {
        //Check box objects
        List<CheckBoxPreference> Keys = new List<CheckBoxPreference>();
        List<CheckBoxPreference> Modes = new List<CheckBoxPreference>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Loads in the xml preference screen
            AddPreferencesFromResource(Resource.Xml.app_preferences);

            //Adds the settings
            Create_Keys();
            Create_Modes();
        }

        public void Create_Keys()
        {
            //Creates the keys settings
            PreferenceCategory Keys_Category = new PreferenceCategory(Activity)
            {
                Title = "Keys"
            };
            PreferenceScreen.AddPreference(Keys_Category);
            foreach (string key in Scales.Core.Settings.keys)
            {
                CheckBoxPreference checkBox = new CheckBoxPreference(Activity)
                {
                    Title = key,
                    Key = key
                };
                PreferenceScreen.AddPreference(checkBox);
                Keys.Add(checkBox);
            }
        }
        public void Create_Modes()

        {
            //Creates the modes settings
            PreferenceCategory Modes_Category = new PreferenceCategory(Activity)
            {
                Title = "Modes"
            };
            PreferenceScreen.AddPreference(Modes_Category);
            foreach (string mode in Scales.Core.Settings.modes)
            {
                CheckBoxPreference checkBox = new CheckBoxPreference(Activity)
                {
                    Title = mode,
                    Key = mode
                };
                PreferenceScreen.AddPreference(checkBox);
                Modes.Add(checkBox);
            }
        }

        //Will run when the page
        public override void OnDestroy()
        {
            base.OnDestroy();

            //Saves the states of the checkboxes
            SaveSwitches(Keys, "keys");
            SaveSwitches(Modes, "modes");
    
            //Updates the active pools
            Settings_Android.SettingAndroid.LoadSettings();
        }

        private void SaveSwitches(List<CheckBoxPreference> list, string type)
        {
            int count = 0;
            foreach (CheckBoxPreference c in list)
            {
                Settings_Android.SettingAndroid.Save(c.Checked, type, count);
                count++;
            }
        }

    }
}
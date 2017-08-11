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
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AddPreferencesFromResource(Resource.Xml.app_preferences);

            //Creates the keys settings
            PreferenceCategory Keys_Category = new PreferenceCategory(Activity)
            {
                Title = "Keys"
            };
            PreferenceScreen.AddPreference(Keys_Category);
            foreach (string key in Settings_Android.keys)
            {
                CheckBoxPreference checkBox = new CheckBoxPreference(Activity)
                {
                    Title = key,
                    Key = key
                };
                PreferenceScreen.AddPreference(checkBox);
            }

            //Creates the modes settings
            PreferenceCategory Modes_Category = new PreferenceCategory(Activity)
            {
                Title = "Modes"
            };
            PreferenceScreen.AddPreference(Modes_Category);
            foreach (string mode in Settings_Android.modes)
            {
                CheckBoxPreference checkBox = new CheckBoxPreference(Activity)
                {
                    Title = mode,
                    Key = mode
                };
                PreferenceScreen.AddPreference(checkBox);
                
            }
        }
    }
}
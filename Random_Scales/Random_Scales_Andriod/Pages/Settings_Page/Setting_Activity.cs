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

using Random_Scales_Andriod.Resources.preferences;
using Android.Preferences;

namespace Random_Scales_Andriod
{
    [Activity(Label = "@string/SettingButton", Theme ="@style/Theme")]
    public class Setting_Activity : PreferenceActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Setup();
        }

        private void Setup()
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            SettingFragment setting = new SettingFragment();
            transaction.Replace(Android.Resource.Id.Content, setting);
            transaction.Commit();
        }


    }
}
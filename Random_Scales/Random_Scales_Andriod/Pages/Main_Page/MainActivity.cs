using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Random_Scales_Andriod.Activities;
using static Random_Scales_Andriod.Resources.settings.Settings_Android;

namespace Random_Scales_Andriod
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Page.Set_ActionBar(ActionBar);
            
            Create_ButtonLinks();
            
            // Setting saving
            SettingAndroid.Assign_Pref(this);
            
            //Sets up for first time load
            SettingAndroid.Initial_Setup();

            //Loads the values
            SettingAndroid.LoadSettings();
        }
        
        //Buttons
        private void Create_ButtonLinks()
        {
            //Scale Button
            TextView scaleButton = FindViewById<TextView>(Resource.Id.Scale_Button);
            scaleButton.Click += ScaleButton_Click;

            //Setting Button
            TextView settingButton = FindViewById<TextView>(Resource.Id.Setting_Button);
            settingButton.Click += SettingButton_Click;
        }

        //Moves the program to another location
        private void SettingButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(Setting_Activity));
            StartActivity(intent);
        }
        private void ScaleButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(Scale_Activity));
            StartActivity(intent);
        }
    }
}


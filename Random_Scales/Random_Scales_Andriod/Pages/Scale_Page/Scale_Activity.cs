﻿using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using static Random_Scales_Andriod.Resources.settings.Settings_Android;

namespace Random_Scales_Andriod.Activities
{
    [Activity(Label = "@string/ScaleButton")]
    public class Scale_Activity : Activity
    {
        //Used to signify what side of the screen has been touched
        TouchPositon Position = new TouchPositon();
        enum TouchPositon
        {
            Left,
            Right
        }

        TextView ScaleText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Scale);
            Page.Set_ActionBar(ActionBar);

            //Creates text
            ScaleText = FindViewById<TextView>(Resource.Id.ScaleText);

            //Creates left and right touch events
            Add_TouchEvent();
        }

        //Runs when the view appears
        protected override void OnResume()
        {
            base.OnResume();

            SettingAndroid.ApplySettings();
            SettingAndroid.SetupScaleShuffle();

            Rnd_ScaleChange();
        }

        private void Add_TouchEvent()
        {
            TextView text = FindViewById<TextView>(Resource.Id.ScaleText);
            text.Touch += Text_Touch;
        }

        private void Text_Touch(object sender, View.TouchEventArgs e)
        {
            switch (e.Event.Action)
            {
                //When the touch ends
                case MotionEventActions.Up:

                    //Gets touch location, the x is only needed because it landscape sides of the screen
                    float x = e.Event.GetX();

                    //Grabs width and hight of the screen
                    var metrics = Resources.DisplayMetrics;
                    float width = metrics.WidthPixels;
                    float midX = width / 2;

                    //Checks position
                    if (x < midX) { Position = TouchPositon.Left; }
                    else { Position = TouchPositon.Right; }

                    //Issues a sacle change
                    Rnd_ScaleChange();
                    break;
                default:
                    break;
            }
        }

        private void Rnd_ScaleChange()
        {
            //Direction
            if (Position == TouchPositon.Right)
            {
                //Adds 1 onto the pool value
                SettingAndroid.PositionInCurrentPool = 1;

            }
            else
            {
                //Takes 1 away from the pool value
                SettingAndroid.PositionInCurrentPool = -1;
                Get_Scale();
            }

            //Checks if the pools need a refresh
            if (!SettingAndroid.PoolEmpty())
            {
                Get_Scale();
            }
            //If first time setup is needed
            else
            {
                SettingAndroid.SetupScaleShuffle();
                Get_Scale();
            }
        }

        private void Get_Scale()
        {
            //Grabs the next scale from the settings page
            string prevS = ScaleText.Text;
            string s = $"{SettingAndroid.NextKey()}\n{SettingAndroid.NextMode()}";
            ScaleText.Text = s;

            //Loads in the image
            ImageView view = FindViewById<ImageView>(Resource.Id.imageView1);
            
            //This is to turn the values into filenames
            string fileName = s.Replace("#", "s");
            fileName = fileName.Replace("\n", "_");
            fileName = fileName.Replace("-", "_");
            fileName = fileName.Replace(" (Alt)", "");
            
            //Grabs the image
            int x = (int)typeof(Resource.Drawable).GetField(fileName).GetVa‌​lue(null);
            view.SetImageResource(x);
        }
    }
}
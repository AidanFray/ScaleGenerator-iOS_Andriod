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
using static Random_Scales_Andriod.Resources.settings.Settings_Android;

namespace Random_Scales_Andriod.Activities
{
    [Activity(Label = "@string/ScaleButton")]
    public class Scale_Activity : Activity
    {
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

            // Create your application here
            ScaleText = FindViewById<TextView>(Resource.Id.ScaleText);


            Add_TouchEvent();

            SettingAndroid.ApplySettings();
            SettingAndroid.SetupScaleShuffle();
        }

        //TODO: Need to check when touch is finished
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
                    //Gets touch location
                    float x = e.Event.GetX();

                    //Grabs width and hight of the screen
                    var metrics = Resources.DisplayMetrics;
                    float width = metrics.WidthPixels;
                    float midX = width / 2;

                    //Checks position
                    if (x < midX) { Position = TouchPositon.Left; }
                    else { Position = TouchPositon.Right; }

                    Rnd_ScaleChange();
                    break;
                default:
                    break;
            }
        }

        private void Rnd_ScaleChange()
        {
            //Checks if the pools need a refresh
            if (!SettingAndroid.PoolEmpty())
            {
                if (Position == TouchPositon.Right)
                {
                    SettingAndroid.movePositionForward();
                    Get_Scale();
                }
                else
                {
                    SettingAndroid.movePositionBack();
                    Get_Scale();

                    SettingAndroid.hello = 1;
                }
            }
            else
            {
                SettingAndroid.SetupScaleShuffle();
            }
        }

        private void Get_Scale()
        {
            string prevS = ScaleText.Text;
            string s = $"{SettingAndroid.NextKey()}\n{SettingAndroid.NextMode()}";

            ScaleText.Text = s;
        }
    }
}
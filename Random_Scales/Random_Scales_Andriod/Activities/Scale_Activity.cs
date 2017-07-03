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

namespace Random_Scales_Andriod.Activities
{
    [Activity(Label = "@string/ScaleButton")]
    public class Scale_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Scale);
            Page.Set_ActionBar(ActionBar);


            // Create your application here
            TextView Scale = FindViewById<TextView>(Resource.Id.ScaleText);
           

            
        }
    }
}
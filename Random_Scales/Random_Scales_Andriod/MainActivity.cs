using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Random_Scales_Andriod
{
    [Activity(Label = "Scales", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<string> mItems = new List<string>();
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Items
            mItems.Add("Test1");
            mItems.Add("Test2");
           
            MyListView adapter = new MyListView(this, mItems);

            ListView listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = adapter;
        }
    }
}


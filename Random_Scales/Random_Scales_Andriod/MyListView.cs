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

namespace Random_Scales_Andriod
{
    class MyListView : BaseAdapter<string>
    {
        private List<string> mItems;
        private Context mContext;

        public MyListView(Context context, List<string> items)
        {
            mItems = items;
            mContext = context;
        }
        
        public override int Count
        {
            get { return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listView_Row, null, false);
            }

            TextView txtName = row.FindViewById<TextView>(Resource.Id.txtView);
            txtName.Text = mItems[position];

            return row;
        }
        
        //Known as an indexer
        public override string this[int position]
        {
            get { return mItems[position]; }
        }
    }
}
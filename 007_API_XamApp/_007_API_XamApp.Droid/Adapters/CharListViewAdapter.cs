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

namespace _007_API_XamApp.Droid
{
    class CharListViewAdapter : BaseAdapter<string>
    {

        private Character listItem;
        Context myContext;

        public CharListViewAdapter(Context context, Character item)
        {
            listItem = item;
            myContext = context;
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
                row = LayoutInflater.From(myContext).Inflate(Resource.Layout.dialog_CharDetailView, null, false);
            }


            TextView txtCharId = row.FindViewById<TextView>(Resource.Id.txtCharName);
            txtCharId.Text = listItems[position].Id;

            TextView txtCharName = row.FindViewById<TextView>(Resource.Id.txtCharName);
            txtCharName.Text = listItems[position].Name;

            return row;
        }
    }
}
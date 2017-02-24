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
    class CharListViewAdapter : BaseAdapter<Character>
    {

        private List<Character> listItems;
        Context myContext;

        public CharListViewAdapter(Context context, List<Character> items)
        {
            listItems = items;
            myContext = context;
        }


        public override Character this[int position]
        {
            get
            {
                return listItems[position];
            }
        }

        public override int Count
        {
            get
            {
                return listItems.Count;
            }
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
                row = LayoutInflater.From(myContext).Inflate(Resource.Layout.CharListView, null, false);
            }


            TextView txtCharId = row.FindViewById<TextView>(Resource.Id.txtCharName);
            txtCharId.Text = listItems[position].Id;

            TextView txtCharName = row.FindViewById<TextView>(Resource.Id.txtCharName);
            txtCharName.Text = listItems[position].Name;

            return row;
        }
    }
}
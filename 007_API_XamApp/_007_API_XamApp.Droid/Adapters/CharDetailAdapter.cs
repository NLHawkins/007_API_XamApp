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

namespace _007_API_XamApp.Droid.Adapters
{
    class CharDetailAdapter : BaseAdapter<Character>
    {
        private Character[] listItems;
        Context myContext;

        public CharDetailAdapter(Activity context, Character[] items) : base()
        {
            this.listItems = items;
            this.myContext = context;
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
                return listItems.Length;
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
                row = LayoutInflater.From(myContext).Inflate(Resource.Layout.dialogListView, null, false);
            }

            TextView txtCharBio = row.FindViewById<TextView>(Resource.Id.txtCharBio);
            txtCharBio.Text = listItems[position].Bio;

            TextView txtCharName = row.FindViewById<TextView>(Resource.Id.txtCharName);
            txtCharName.Text = listItems[position].Name;

            return row;
        }
    }
}
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
    class MovieNameListViewAdapter : BaseAdapter<Movie>
    {
        private List<Movie> listItems;
        Context myContext;

        public MovieNameListViewAdapter(Context context, List<Movie> items)
        {
            listItems = items;
            myContext = context;
        }


        public override Movie this[int position]
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
                row = LayoutInflater.From(myContext).Inflate(Resource.Layout.MovieNameListView, null, false);
            }

            TextView txtMovieId = row.FindViewById<TextView>(Resource.Id.txtMovieId);
            txtMovieId.Text = listItems[position].Id;

            TextView txtMovieTitle = row.FindViewById<TextView>(Resource.Id.txtMovieTitle);
            txtMovieTitle.Text = listItems[position].Title;

            return row;
        }
    }
}
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
    class MovieListAdapter : BaseAdapter<Movie>
    {
        private Context mContext;
        private int mLayout;
        private List<Movie> mMovies;



        public MovieListAdapter(Context context, int layout, List<Movie> movies)
        {
            mContext = context;
            mLayout = layout;
            mMovies = movies;
        }

        public override Movie this[int position]
        {
            get
            {
                return mMovies[position];
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get
            {
                return mMovies.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.movieListView_row, parent, false);
            }

            TextView movieListTextView = row.FindViewById<TextView>(Resource.Id.movieListTextView);
            movieListTextView.Text = mMovies[position].Title;

             return row;
        }

    }
    
}
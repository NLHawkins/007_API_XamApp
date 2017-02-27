using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using _007_API_XamApp.Droid.Adapters;

namespace _007_API_XamApp.Droid
{
    public class dialog_CharDetailFragment : DialogFragment
    {
        public TextView mNameView;
        public TextView mBioView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialogListView, container, false);

            
            return view;
        }


    }
}
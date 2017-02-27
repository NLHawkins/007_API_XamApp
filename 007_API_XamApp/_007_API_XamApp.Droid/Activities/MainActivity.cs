using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using _007_API_XamApp.Droid.Adapters;
using _007_API_XamApp.Droid.Activities;

namespace _007_API_XamApp.Droid
{
    [Activity(Label = "007 Droid API", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button getCharsButton = FindViewById<Button>(Resource.Id.getCharsButton);
            getCharsButton.Click += getCharsButton_clicked;
            /*
            Button getMoviesButton = FindViewById<Button>(Resource.Id.getMoviesButton);
            getMoviesButton.Click += getMoviesButton_clicked;
            */
            Button getGadgetsButton = FindViewById<Button>(Resource.Id.getGadgetsButton);
            getGadgetsButton.Click += getGadgetsButton_clicked;
        }

        private void getCharsButton_clicked(object sender, EventArgs e)
        {
            var charIntent = new Intent(this, typeof(CharActivity));
            StartActivity(charIntent);
        }
        /*
        private void getMoviesButton_clicked(object sender, EventArgs e)
        {
            var movieIntent = new Intent(this, typeof(MovieActivity));
            StartActivity(movieIntent);
        }
        */
        private void getGadgetsButton_clicked(object sender, EventArgs e)
        {
            var gadgetIntent = new Intent(this, typeof(GadgetActivity));
            StartActivity(gadgetIntent);
        }
    }
}




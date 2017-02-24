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

namespace _007_API_XamApp.Droid
{
    [Activity(Label = "007 Droid API", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //private object charListItems;
        private ListView charNameListView;

        private string charDataString;

        private Uri BaseUri = new Uri("http://007api.co/api/characters");

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button GetCharsButton = FindViewById<Button>(Resource.Id.getCharsButton);
            GetCharsButton.Click += delegate
            {
                charDataString = GetChars();
                charNameListView = FindViewById<ListView>(Resource.Id.charNameListView);
                var characterCollection = JsonConvert.DeserializeObject<CharacterCollection>(charDataString);
                var charListItems = characterCollection.results;
                CharNameListViewAdapter adapter = new CharNameListViewAdapter(this, charListItems);
                charNameListView.Adapter = adapter;
            };
        }

        public string GetChars()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://007api.co/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("api/characters/").Result;
                string data = response.Content.ReadAsStringAsync().Result;
                return data;
            };
        }
    }
}




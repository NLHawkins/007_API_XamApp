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
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using _007_API_XamApp.Droid.Adapters;

namespace _007_API_XamApp.Droid.Activities
{
    [Activity(Label = "CharActivity")]
    public class CharActivity : Activity
    {
        private ListView charNameListView;
        private CharacterCollection prevCharCol;
        private List<Character> mChars;
        //private Character mChar;
        private string charDataString;

        private Uri BaseUri = new Uri("http://007api.co/api/characters");

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CharNameList);
            prevCharCol = new CharacterCollection();
            charDataString = GetChars();
            var charNameList = FindViewById<ListView>(Resource.Id.charNameList);
            var characterCollection = JsonConvert.DeserializeObject<CharacterCollection>(charDataString);
            mChars = characterCollection.results;
            CharNameListViewAdapter adapter = new CharNameListViewAdapter(this, mChars);
            charNameList.Adapter = adapter;

            charNameList.ItemClick += charNameList_ItemClick;


        }

        private void charNameList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            charDataString = GetChars();
            var characterCollection = JsonConvert.DeserializeObject<CharacterCollection>(charDataString);
            var charList = characterCollection.results;
            Character[] charArray = new Character[] { charList[e.Position] };

            dialog_CharDetailFragment charFrag = new dialog_CharDetailFragment();
            var dialogView = FindViewById<ListView>(Resource.Id.dialogCharList);
            CharDetailAdapter adapter = new CharDetailAdapter(this, charArray);
            dialogView.Adapter = adapter;
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_CharDetailFragment charDetail = new dialog_CharDetailFragment();
            charDetail.Show(transaction, "dialog fragment");

            /*
            var data = GetCharDetails(int.Parse(mChars[e.Position].Id));
            mChar = JsonConvert.DeserializeObject<Character>(data);
            Character[] charCharArray = newCh
            var intent = new Intent(this, typeof(CharDetailActivity));

            
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_CharDetailFragment charDetail = new dialog_CharDetailFragment();
            charDetail.
            charDetail.Show(transaction, "dialog fragment");
            */




        }

        private string GetCharDetails(int charId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://007api.co/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync($"api/characters/{charId}").Result;
                string data = response.Content.ReadAsStringAsync().Result;
                return data;
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

        private string GetNextChars(HttpClient client, Uri page)
        {
            client.BaseAddress = new Uri("http://007api.co/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string pageNumber = page.Query;
            if (page != null)
            {
                var response = client.GetAsync($"api/characters/{pageNumber}").Result;
                string data = response.Content.ReadAsStringAsync().Result;
                return data;
            }

            return this.ToString();

        }
    }
}
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
    [Activity(Label = "MovieActivity")]
    public class MovieActivity : Activity
    {
        private ListView movieNameListView;
        private MovieCollection mMovieCol;
        private List<Movie> mMovies;
        private Movie mMovie;
        private string MovieDataString;

        private Uri BaseUri = new Uri("http://007api.co/api/Movies");

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button GetMoviesButton = FindViewById<Button>(Resource.Id.getMoviesButton);
            GetMoviesButton.Click += delegate
            {
                MovieDataString = GetMovies(mMovieCol);
                movieNameListView = FindViewById<ListView>(Resource.Id.MovieNameListView);
                var MovieCollection = JsonConvert.DeserializeObject<MovieCollection>(MovieDataString);
                mMovies = MovieCollection.Results;
                MovieNameListViewAdapter adapter = new MovieNameListViewAdapter(this, mMovies);
                movieNameListView.Adapter = adapter;
            };

            Button GetNextMoviesButton = FindViewById<Button>(Resource.Id.getMoviesButton);
            GetMoviesButton.Click += delegate
            {
                MovieDataString = GetMovies(mMovieCol);
                movieNameListView = FindViewById<ListView>(Resource.Id.MovieNameListView);
                var MovieCollection = JsonConvert.DeserializeObject<MovieCollection>(MovieDataString);
                mMovies = MovieCollection.Results;
                MovieNameListViewAdapter adapter = new MovieNameListViewAdapter(this, mMovies);
                movieNameListView.Adapter = adapter;
            };

            movieNameListView = FindViewById<ListView>(Resource.Id.MovieNameListView);
            movieNameListView.ItemClick += MovieNameListView_ItemClick;
        }

        private void MovieNameListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var data = GetMovieDetails(int.Parse(mMovies[e.Position].Id));
            mMovie = JsonConvert.DeserializeObject<Movie>(data);
            var intent = new Intent(this, typeof(MovieDetailActivity));
            FragmentTransaction transaction = FragmentManager.BeginTransaction();

        }

        private string GetMovieDetails(int MovieId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://007api.co/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync($"api/Movies/{MovieId}").Result;
                string data = response.Content.ReadAsStringAsync().Result;
                return data;
            };

        }

        public string GetMovies(MovieCollection MovieCol)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://007api.co/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("api/Movies/").Result;
                string data = response.Content.ReadAsStringAsync().Result;
                return data;
            };
        }

        private string GetNextMovies(HttpClient client, Uri page)
        {
            client.BaseAddress = new Uri("http://007api.co/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string pageNumber = page.Query;
            if (page != null)
            {
                var response = client.GetAsync($"api/Movies/{pageNumber}").Result;
                string data = response.Content.ReadAsStringAsync().Result;
                return data;
            }

            return this.ToString();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace _007_API_XamApp.Droid
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public List<string> Characters { get; set; }
    }

     public class MovieCollection
    {
        public string Count { get; set; }
        public Uri Next { get; set; }
        public Uri Previous { get; set; }
        public List<Movie> Results { get; set; }

        /*
        public Task<MovieCollection> GetAllMovies()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://007api.co/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = httpClient.GetAsync("api/movies/").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content;
                string jsonData = content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<MovieCollection>(jsonData);
            }
            return new MovieCollection;
        }
        */
    }
}

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
    public class CharacterCollection
    {
        public List<Character> results { get; set; }
        public string Count { get; set; }
        public Uri Next { get; set; }
        public Uri Previous { get; set; }
    }

    public class Character
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
    }
}
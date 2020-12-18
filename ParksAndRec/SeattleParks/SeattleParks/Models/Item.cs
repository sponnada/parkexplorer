using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace SeattleParks.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Text { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string MainImage { get; set; }

        public List<string> GalleryImages { get; set; }

        public string AmenitiesList { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public bool IsFavorite { get; set; }
    }
}
using System.Collections.Generic;
using AngleSharp;

namespace ExternalDataClients.ScrapeSeattleParksData
{
    public class SeattleParkScrappedData
    {

        public SeattleParkScrappedData()
        {

        }

        public SeattleParkScrappedData(string url, string title, string hours, string phone, string address, string about, string mainImage, List<string> galleryImages, List<string> amenities)      {
            this.Url = url;
            this.Title = title;
            this.Hours = hours;
            this.Phone = phone;
            this.Address = address;
            this.About = about;
            this.MainImage = mainImage;
            this.GalleryImages = galleryImages;
            this.Amenities = amenities;
        }

        public string Url { get; set; }
        public string Title { get; set; }
        public string Hours { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public string MainImage { get; set; }
        public List<string> GalleryImages { get; set; }
        public List<string> Amenities { get; set; }
    }
}
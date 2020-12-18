using ExternalDataClients.ScrapeSeattleParksData;

namespace ExternalDataClients
{
    public class SeattleParkInfo : SeattleParkScrappedData
    {
        public SeattleParkInfo(object name, object longitudeObj, object latitudeObj, SeattleParkScrappedData seattleParkScrappedData)
        {
            this.Name = name.ToString();
            float.TryParse(longitudeObj?.ToString(), out var longitude);
            float.TryParse(latitudeObj?.ToString(), out var latitude);
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.Url = seattleParkScrappedData?.Url;
            this.Title = seattleParkScrappedData?.Title;
            this.Hours = seattleParkScrappedData?.Hours;
            this.Phone = seattleParkScrappedData?.Phone;
            this.Address = seattleParkScrappedData?.Address;
            this.About = seattleParkScrappedData?.About;
            this.MainImage = seattleParkScrappedData?.MainImage;
            this.GalleryImages = seattleParkScrappedData?.GalleryImages;
            this.Amenities = seattleParkScrappedData?.Amenities;
        }

        public string Name { get; set; }

        public float Longitude { get; set; }

        public float Latitude { get; set; }
    }
}
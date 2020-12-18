using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExternalDataClients.ScrapeSeattleParksData;
using ExternalDataClients.SeattleParksData;
using Newtonsoft.Json;

namespace ExternalDataClients
{
    public class SeattleParks
    {
        public static List<SeattleParkInfo> SeattleParkList { get; set; }
        public static List<SeattleParkScrappedData> SeattleParkScrappedDataList { get; set; }

        static SeattleParks()
        {
            SeattleParkScrappedDataList = JsonConvert.DeserializeObject<List<SeattleParkScrappedData>>(File.ReadAllText(@".\CachedData\SeattleParksScrappedData.json"));

            //Read Cached data
            SeattleParkList = GetSeattleParksCachedData();
        }

        private static List<SeattleParkInfo> GetSeattleParksCachedData()
        {
            var parks = JsonConvert.DeserializeObject<SeattleParksCachedData>(File.ReadAllText(@".\CachedData\SeattleParks.json"));
            var seattleParkList = new List<SeattleParkInfo>();

            var nameOrdinal = -1;
            var longitudeOrdinal = -1;
            var latitudeOrdinal = -1;

            var columnPositionCounter = 0;
            foreach (var column in parks.meta.view.columns)
            {
                if (column.name.Equals("name", StringComparison.InvariantCultureIgnoreCase))
                {
                    nameOrdinal = columnPositionCounter;
                }

                if (column.name.Equals("xpos", StringComparison.InvariantCultureIgnoreCase))
                {
                    longitudeOrdinal = columnPositionCounter;
                }

                if (column.name.Equals("ypos", StringComparison.InvariantCultureIgnoreCase))
                {
                    latitudeOrdinal = columnPositionCounter;
                }

                columnPositionCounter++;
            }

            foreach (var park in parks.data)
            {
                if (seattleParkList?.Where(p => string.IsNullOrWhiteSpace(p.Name) == false && p.Name.Equals(park[nameOrdinal])).Any() == false)
                {
                    var scrappedData = SeattleParkScrappedDataList
                        .FirstOrDefault(p => string.IsNullOrWhiteSpace(p.Title) == false
                                             && p.Title.Equals(park[nameOrdinal].ToString(), StringComparison.InvariantCultureIgnoreCase));

                    var sp = new SeattleParkInfo(park[nameOrdinal],
                        park[longitudeOrdinal],
                        park[latitudeOrdinal],
                        scrappedData);

                    seattleParkList.Add(sp);
                }
            }

            return seattleParkList;
        }

        public IReadOnlyList<ParkReview> GetAllParkYelpReviews()
        {
            List<ParkReview> reviews = new List<ParkReview>();
            var yelp = new YelpApiClient();

            foreach (var p in SeattleParkList)
            {
                var review = yelp.GetParkReview(p);

                Console.WriteLine($"{p.Name}, {review.TotalReviews}, {review.AvgReview}");

                reviews.Add(review);
            }

            return reviews;
        }
    }
}
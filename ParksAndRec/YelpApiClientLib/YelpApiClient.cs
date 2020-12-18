using System;
using System.Collections.Generic;
using System.Linq;
using Yelp.Api.Models;

namespace ExternalDataClients
{
    public class YelpApiClient
    {
        private string _token = "uGJX2RJWCUoPBQd__2gJZXgA-PrgSQ0ufKGMUYEENAoC-LRltGX70wcmPOPQCtuICUJAnUMgi2VsYRydVDnbmqL5x00hTgywL6TzYl-MwdzRcI7YNx41BqQueXhWW3Yx";
        private Yelp.Api.Client _yelpClient = null;
        public Yelp.Api.Client YelpClient
        {
            get
            {
                if (_yelpClient == null)
                {
                    _yelpClient = new Yelp.Api.Client(_token);
                }

                return _yelpClient;
            }
        }

        public ParkReview GetParkReview(SeattleParkInfo park)
        {
            var findPark = YelpClient.SearchBusinessesAllAsync(park.Name, park.Latitude, park.Longitude).Result;
            //BusinessResponse results = YelpClient.GetBusinessAsync(findPark.Businesses.FirstOrDefault().Name).Result;

            return new ParkReview(findPark.Businesses.FirstOrDefault());
        }

        public List<ParkReview> GetParksReview(List<string> parkKeys)
        {
            List<ParkReview> parkReviews = new List<ParkReview>();
            foreach (var parkKey in parkKeys)
            {
                BusinessResponse results = YelpClient.GetBusinessAsync(parkKey).Result;
                parkReviews.Add(new ParkReview(results));
            }

            return parkReviews;
        }
    }
}

using Yelp.Api.Models;

namespace ExternalDataClients
{
    public class ParkReview
    {
        public ParkReview(BusinessResponse results)
        {
            if (results != null)
            {
                this.TotalReviews = results.ReviewCount;
                this.AvgReview = results.Rating;
                this.YelpUrl = results.Url;
            }
        }

        public int TotalReviews { get; set; }
        public float AvgReview { get; set; }
        public string YelpUrl { get; set; }
    }
}
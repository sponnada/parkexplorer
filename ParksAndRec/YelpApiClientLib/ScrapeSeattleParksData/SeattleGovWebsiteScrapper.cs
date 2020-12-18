using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using Newtonsoft.Json;

namespace ExternalDataClients.ScrapeSeattleParksData
{
    public class SeattleGovWebsiteScrapper
    {
        private const string Path = @".\CachedData\SeattleParksScrappedData.json";
        private const string BaseUrl = "https://www.seattle.gov";
        private const string ParksUrlPart = @"/parks/find/parks/";

        public async Task Scrape()
        {
            var config = Configuration.Default.WithDefaultLoader();

            var document = await BrowsingContext.New(config).OpenAsync($"{BaseUrl}{ParksUrlPart}parks-a-d");

            var links = document
                .QuerySelectorAll($"ul[data-childrentarget^=Parks] > li > a[href^='{ParksUrlPart}']")
                .Select(m => m.Attributes["href"].Value);

            var parks = await Task.WhenAll(links.Select(async link => {
                document = await BrowsingContext.New(config).OpenAsync(BaseUrl + link);

                return new SeattleParkScrappedData
                (
                    BaseUrl + link,
                    document.QuerySelector("h1.pageTitle")?.TextContent?.Trim(),
                    document.QuerySelector("div.parkHoursAndContactContainer > span")?.TextContent,
                    document.QuerySelector("div.featureContactPhoneNumber")?.TextContent,
                    document.QuerySelector("div.parkHoursAndContactContainer a")?.TextContent,
                    document.QuerySelector("h2 + p")?.TextContent,
                    BaseUrl + document.QuerySelector("div[data-backgroundurl^='/images']")?.Attributes["data-backgroundurl"]?.Value,
                    document.QuerySelectorAll(".imageGalleryImage img").Select(d => BaseUrl + "/" + d.Attributes["src"].Value).ToList(),
                    document.QuerySelectorAll(".pa").Select(d => d.Attributes["class"].Value.Replace("pa pa-", "")).ToList()
                );
            }));

            File.WriteAllText(Path, JsonConvert.SerializeObject(parks, Newtonsoft.Json.Formatting.Indented));
        }
    }
}

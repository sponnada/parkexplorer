using System;
using System.Collections.Generic;

namespace SeattleParks.Data
{
    /// <summary>
    /// Represents the Parks.json file
    /// </summary>
    public class ParkDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public string Hours { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string About { get; set; }

        public string MainImage { get; set; }

        public ICollection<string> Amenities { get; set; }

        public ICollection<string> GalleryImages { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }
    }
}

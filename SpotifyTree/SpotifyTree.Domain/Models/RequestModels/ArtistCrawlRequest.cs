using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyTree.Domain.Models.RequestModels
{
    public class ArtistCrawlRequest
    {
        public string ArtistName { get; set; }
        public string ArtistId { get; set; }
        public int TopSongsLimit { get; set; } = 3;
        public int TopArtistLimit { get; set; }
        public string CountryOrigin { get; set; } = "US";
        public int ArtistSearchLimit { get; set; } = 25;

    }
}

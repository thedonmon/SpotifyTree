using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyTree.Domain.Models.ResponseModels
{
    public class ArtistCrawlResponse
    {
        public string ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string SongUri { get; set; }
        public string SongId { get; set; }
        public string SongName { get; set; }
        public int Duration { get; set; }
    }
}

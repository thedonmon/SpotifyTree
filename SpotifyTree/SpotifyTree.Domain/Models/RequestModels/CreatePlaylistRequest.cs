using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyTree.Domain.Models.RequestModels
{
    public class CreatePlaylistRequest
    {
        public string PlaylistName { get; set; }
        public IEnumerable<string> SongIds { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
    }
}

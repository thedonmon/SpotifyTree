using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SpotifyTree.Domain.Interfaces;
using SpotifyTree.Domain.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SpotifyTree.Domain.Models.ResponseModels;

namespace SpotifyTree.Domain.Implementations
{
    public class AritstCrawler : IArtistCrawler
    {
        //private static string _clientId = Environment.GetEnvironmentVariable("ClientId"); 
        //private static string _secretId = Environment.GetEnvironmentVariable("ClientSecret");

        private static string _clientId = "56fe9ecd118c4d5699bc17e3bc7b4350";
        private static string _secretId = "8cef3776f2ff4daa94ba0de3300e0c3d";

        private SpotifyWebAPI spotifyApi;

        public async Task<bool> CreatePlayListAsync(CreatePlaylistRequest request)
        {
            spotifyApi = new SpotifyWebAPI
            {
                AccessToken = request.AccessToken,
                TokenType = request.TokenType
            };
            var userId = await spotifyApi.GetPrivateProfileAsync();
            var playlist = await spotifyApi.CreatePlaylistAsync(userId.Id, $"SpotifyTree - {request.PlaylistName}");
            var addToPlaylist = await spotifyApi.AddPlaylistTracksAsync(playlist.Id, request.SongIds.ToList());

            return true;
        }

        public async Task<IEnumerable<ArtistCrawlResponse>> GetAndCreateRelatedArtist(ArtistCrawlRequest request)
        {
            List<ArtistCrawlResponse> songIds = new List<ArtistCrawlResponse>();
            if(string.IsNullOrEmpty(_clientId) || string.IsNullOrEmpty(_secretId))
            {
                throw new ArgumentException("ClientId and/or ClientSecret must be provided");
            }
            CredentialsAuth auth = new CredentialsAuth(_clientId, _secretId);
            var token = await auth.GetToken();
            spotifyApi = new SpotifyWebAPI
            {
                AccessToken = token.AccessToken,
                TokenType = token.TokenType
            };

            var searchRequest = await spotifyApi.SearchItemsAsync(request.ArtistName, SearchType.Artist, limit: 10, market: request.CountryOrigin);
            var artistFromSearch = searchRequest.Artists.Items.Where(x => x.Name.Equals(request.ArtistName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            var artistId = artistFromSearch.Id;

            var relatedArtists = await spotifyApi.GetRelatedArtistsAsync(artistId);

            foreach (var artist in relatedArtists.Artists)
            {
                var topTracks = await spotifyApi.GetArtistsTopTracksAsync(artist.Id, request.CountryOrigin);
                var tracksToAdd = topTracks.Tracks.Take(request.TopSongsLimit);
                var responseToAdd = tracksToAdd.Select(x => new ArtistCrawlResponse
                {
                    ArtistId = artist.Id,
                    ArtistName = artist.Name,
                    SongId = x.Id,
                    SongName = x.Name,
                    Duration = x.DurationMs,
                    SongUri = x.Uri

                });
                songIds.AddRange(responseToAdd);
            }
            songIds = songIds.OrderBy(x => x.SongId).ToList();
            return songIds;
        }

        public Task<IEnumerable<ArtistCrawlResponse>> GetAndCreateRelatedArtist(IEnumerable<ArtistCrawlRequest> request)
        {
            throw new NotImplementedException();
        }
    }
}

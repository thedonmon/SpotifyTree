using SpotifyTree.Domain.Models;
using SpotifyTree.Domain.Models.RequestModels;
using SpotifyTree.Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyTree.Domain.Interfaces
{
    public interface IArtistCrawler
    {
        Task<IEnumerable<ArtistCrawlResponse>> GetAndCreateRelatedArtist(ArtistCrawlRequest request);
        Task<IEnumerable<ArtistCrawlResponse>> GetAndCreateRelatedArtist(IEnumerable<ArtistCrawlRequest> request);
        Task<ValidationResponse> CreatePlayListAsync(CreatePlaylistRequest request);
    }
}

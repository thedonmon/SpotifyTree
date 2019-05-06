using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyTree.Domain.Interfaces;
using SpotifyTree.Domain.Models.RequestModels;
using SpotifyTree.Domain.Models.ResponseModels;

namespace SpotifyTree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly IArtistCrawler _crawler;
        public HomeController(IArtistCrawler crawler)
        {
            _crawler = crawler;

        }
      
        // GET: api/Home/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Home
        [HttpPost]
        public async Task<IEnumerable<ArtistCrawlResponse>> Post([FromBody] ArtistCrawlRequest request)
        {
            return await _crawler.GetAndCreateRelatedArtist(request);

        }
        [HttpPost]
        [Route("getMultipleArtists")]
        public async Task<IEnumerable<ArtistCrawlResponse>> Post([FromBody] IEnumerable<ArtistCrawlRequest> request)
        {
            return await _crawler.GetAndCreateRelatedArtist(request);

        }
        [HttpPost]
        [Route("createPlaylist")]
        public async Task<IActionResult> CreatePlaylist([FromBody] CreatePlaylistRequest request)
        {
            var response = await _crawler.CreatePlayListAsync(request);
            if(response.Success)
                return Ok();
            else
            {
                return BadRequest($"Error while creating playlist: {response.Message}; StatusCode: {response.StatusCode}");
            }

        }

    }
}

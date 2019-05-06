using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyTree.Domain.Models
{
    public class ValidationResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public int HttpStatusCode { get; set; }
    }
}

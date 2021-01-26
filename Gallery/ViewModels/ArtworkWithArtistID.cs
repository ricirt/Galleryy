using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.ViewModels
{
    public class ArtworkWithArtistID
    {
        public int Awid { get; set; }
        public string Awname { get; set; }
        public DateTime Awdate { get; set; }
        public string Awinformation { get; set; }
        public string Awtype { get; set; }
        public decimal? Awvalue { get; set; }
        public int Aid { get; set; }
    }
}

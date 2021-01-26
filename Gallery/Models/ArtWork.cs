using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Gallery.Models
{
    public partial class ArtWork
    {
        public ArtWork()
        {
            GroupArtworks = new HashSet<GroupArtwork>();
        }

        public int Awid { get; set; }

        public string Awname { get; set; }
        public DateTime? Awdate { get; set; }
        public string Awinformation { get; set; }
        public string Awtype { get; set; }
        public decimal? Awvalue { get; set; }
        public int? Aid { get; set; }

        public virtual Artist AidNavigation { get; set; }
        public virtual ICollection<GroupArtwork> GroupArtworks { get; set; }
    }
}

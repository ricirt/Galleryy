using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Gallery.Models
{
    public partial class Artist
    {
        public Artist()
        {
            ArtWorks = new HashSet<ArtWork>();
            GroupArtists = new HashSet<GroupArtist>();
        }

        public int Aid { get; set; }

        public string Aname { get; set; }
        public DateTime? Aborn { get; set; }
        public DateTime? Adied { get; set; }
        public int? AnumberOfWork { get; set; }
        public string Ainformation { get; set; }

        public virtual ICollection<ArtWork> ArtWorks { get; set; }
        public virtual ICollection<GroupArtist> GroupArtists { get; set; }
    }
}

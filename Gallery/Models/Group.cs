using System;
using System.Collections.Generic;

#nullable disable

namespace Gallery.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupArtists = new HashSet<GroupArtist>();
            GroupArtworks = new HashSet<GroupArtwork>();
        }

        public string Gname { get; set; }
        public string Ginfo { get; set; }
        public int Gid { get; set; }

        public virtual ICollection<GroupArtist> GroupArtists { get; set; }
        public virtual ICollection<GroupArtwork> GroupArtworks { get; set; }
    }
}

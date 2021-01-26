using System;
using System.Collections.Generic;

#nullable disable

namespace Gallery.Models
{
    public partial class GroupArtwork
    {
        public int Awid { get; set; }
        public int Gid { get; set; }

        public virtual ArtWork Aw { get; set; }
        public virtual Group GidNavigation { get; set; }
    }
}

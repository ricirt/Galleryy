using System;
using System.Collections.Generic;

#nullable disable

namespace Gallery.Models
{
    public partial class GroupArtist
    {
        public int Gid { get; set; }
        public int Aid { get; set; }

        public virtual Artist AidNavigation { get; set; }
        public virtual Group GidNavigation { get; set; }
    }
}

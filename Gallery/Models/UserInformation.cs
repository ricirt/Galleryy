using System;
using System.Collections.Generic;

#nullable disable

namespace Gallery.Models
{
    public partial class UserInformation
    {
        public int Uid { get; set; }
        public string Urole { get; set; }
        public string Uname { get; set; }
        public int? Uage { get; set; }
        public string Umail { get; set; }
        public string Uprofession { get; set; }
        public virtual UserLogin UserLogin { get; set; }
    }
}

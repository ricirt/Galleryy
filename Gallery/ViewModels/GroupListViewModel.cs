using System;
using System.Collections.Generic;
using System.Text;
using Gallery.Models;

namespace Gallery.ViewModels
{
    public class GroupListViewModel
    {
        public string Gname { get; set; }
        public string Ginfo { get; set; }
        public int Gid { get; set; }
        public List<string> ArtistName { get; set; }
        public List<string> ArtWorkName { get; set; }
    }
}

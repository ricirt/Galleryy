using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gallery.ViewModels
{
     public class ProfilViewModel
    {
        public string UName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int? Uage { get; set; }
        public string Umail { get; set; }
        public string Uprofession { get; set; }
        public string Urole { get; set; }
    }
}

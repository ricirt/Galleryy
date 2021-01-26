using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Gallery.Models
{
    public partial class UserLogin
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual UserInformation Login { get; set; }
    }
}

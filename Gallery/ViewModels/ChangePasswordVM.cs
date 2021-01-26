using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gallery.ViewModels
{
    public class ChangePasswordVM
    {
        [Required]
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string newPasswordConfirm { get; set; }
        public string username { get; set; }
    }
}

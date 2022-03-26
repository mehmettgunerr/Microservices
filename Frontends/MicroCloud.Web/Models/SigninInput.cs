﻿using System.ComponentModel.DataAnnotations;

namespace MicroCloud.Web.Models
{
    public class SigninInput
    {
        [Display(Name ="Email Adresiniz")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Şifreniz")]
        [Required]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        [Required]
        public bool IsRemember { get; set; }
    }
}

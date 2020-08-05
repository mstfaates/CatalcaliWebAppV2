using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CatalcaliWebAppV2.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Ad")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyad")]
        public string SurName { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Eposta")]
        [EmailAddress(ErrorMessage = "Eposta adresinizi doğru girdiğinizden emin olun.")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreleriniz uyuşmuyor.")]
        public string RePassword { get; set; }
    }
}
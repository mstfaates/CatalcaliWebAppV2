using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CatalcaliWebAppV2.Models
{
    public class ShippingDetailsViewModel
    {
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen İsim giriniz.")]
        public string İsim { get; set; }
        [Required(ErrorMessage = "Lütfen Soyisim giriniz.")]
        public string Soyisim { get; set; }

        [Required(ErrorMessage = "Lütfen adres tanımını giriniz.")]
        public string AdresBasligi { get; set; }

        [Required(ErrorMessage = "Lütfen bir adres giriniz.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen şehir giriniz.")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen semt giriniz.")]
        public string İlce { get; set; }

        [Required(ErrorMessage = "Lütfen telefon giriniz.")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Lütfen eposta giriniz.")]
        public string Eposta { get; set; }
        public string PostaKodu { get; set; }
        public string OrderNote { get; set; }
        public Cart cart { get; set; }
    }
}
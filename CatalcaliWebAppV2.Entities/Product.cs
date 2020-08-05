using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalcaliWebAppV2.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Ürün Adı boş bırakılamaz.")]
        [DisplayName("Ürün Adı")]
        [StringLength(maximumLength: 300, ErrorMessage = "Ürün ismi minimum 3 karakter ve maksimum 60 karakter olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ürün Açıklaması boş bırakılamaz")]
        [DisplayName("Ürün Açıklama")]
        [StringLength(maximumLength: 500, ErrorMessage = "Ürün açıklaması minimum 20 karakter ve maksimum 500 karakter olmalıdır.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Ürün Fiyatı boş bırakılamaz.")]
        [DisplayName("Fiyat")]
        [DataType(DataType.Currency, ErrorMessage = "Format desteklenmemektedir.")]
        public double Price { get; set; }
        [DisplayName("Stok")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Sadece sayı giriniz.")]
        public int Stock { get; set; }
        [DisplayName("Miktar")]
        [RegularExpression(@"^[a-zA-Z0-9,. ]*$")]
        public string Weight { get; set; }
        [DisplayName("Fotoğraf")]
        [DataType(DataType.ImageUrl, ErrorMessage = "Format desteklenmemektedir.")]
        public string Image { get; set; }
        [StringLength(maximumLength: 125, ErrorMessage = "Fotoğrafın açıklaması maksimum 125 karakter olmalıdır.")]
        [DisplayName("Fotoğraf Açıklaması")]
        public string ImageDescription { get; set; }
        [DisplayName("Ana Sayfada")]
        public bool IsHome { get; set; }
        [DisplayName("Satışta")]
        public bool IsApproved { get; set; }
        [DisplayName("Kategorisi")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}

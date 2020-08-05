using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalcaliWebAppV2.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string İsim { get; set; }
        [Required]
        public string Soyisim { get; set; }
        [Required]
        public string AdresBasligi { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public string Sehir { get; set; }
        [Required]
        public string İlce { get; set; }
        [Required]
        public string PostaKodu { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public string Eposta { get; set; }
        public string OrderNote { get; set; }
        public virtual Shipping Shipping { get; set; }

        public virtual List<OrderLine> Orderlines { get; set; }
    }

    public class OrderLine
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int ShippingId { get; set; }
        public virtual Shipping Shipping { get; set; }
    }
}

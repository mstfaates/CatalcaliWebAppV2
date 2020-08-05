using CatalcaliWebAppV2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalcaliWebAppV2.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }

        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string İlce { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public string PostaKodu { get; set; }
        public string OrderNote { get; set; }
        public string İsim { get; set; }
        public string Soyisim { get; set; }

        public virtual List<OrderLineModel> Orderlines { get; set; }
    }

    public class OrderLineModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
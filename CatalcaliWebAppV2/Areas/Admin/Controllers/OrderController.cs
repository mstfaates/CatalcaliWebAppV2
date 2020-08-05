using CatalcaliWebAppV2.Areas.Admin.Models;
using CatalcaliWebAppV2.Entities;
using CatalcaliWebAppV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatalcaliWebAppV2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        DataContext _context = new DataContext();
        public double shipping = 0;
        // GET: Order
        public ActionResult NewOrder()
        {
            var ship = _context.Shippings.Where(i => i.ShippingId == 1);
            var orders = _context.Orders.Where(i => i.OrderState == EnumOrderState.Bekleyen)
                .Select(i => new AdminOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    Total = i.Total + shipping,
                    Count = i.Orderlines.Count,
                    İsim = i.İsim,
                    Soyisim = i.Soyisim,
                    Adres = i.Adres,
                }).OrderByDescending(i => i.OrderDate).ToList();

            return View(orders);
        }
        public ActionResult Delivered()
        {
            var orders = _context.Orders.Where(i => i.OrderState == EnumOrderState.Tamamlandı)
                .Select(i => new AdminOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    Total = i.Total,
                    Count = i.Orderlines.Count,
                    İsim = i.İsim,
                    Soyisim = i.Soyisim,
                    Adres = i.Adres,

                }).OrderByDescending(i => i.OrderDate).ToList();

            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var entity = _context.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    UserName = i.Username,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Sehir = i.Sehir,
                    İlce = i.İlce,
                    Telefon = i.Telefon,
                    Eposta = i.Eposta,
                    PostaKodu = i.PostaKodu,
                    İsim = i.İsim,
                    Soyisim = i.Soyisim,
                    OrderNote = i.OrderNote,
                    Orderlines = i.Orderlines.Select(a => new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name,
                        Image = a.Product.Image,
                        Quantity = a.Quantity,
                        Price = a.Price
                    }).ToList()
                }).FirstOrDefault();
            return View(entity);
        }

        public ActionResult UpdateOrderState(int OrderId, EnumOrderState OrderState)
        {
            var order = _context.Orders.FirstOrDefault(i => i.Id == OrderId);

            if (order != null)
            {
                order.OrderState = OrderState;
                _context.SaveChanges();

                TempData["message"] = "Bilgileriniz Kayıt Edildi";

                return RedirectToAction("Details", new { id = OrderId });
            }

            return RedirectToAction("Index");
        }
        public double ShippingFee()
        {
            Shipping shippings = _context.Shippings.FirstOrDefault(x => x.ShippingId == 1);
            return shipping = shippings.ShippingFee;
        }

    }
}
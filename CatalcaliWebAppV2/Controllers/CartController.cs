using CatalcaliWebAppV2.Entities;
using CatalcaliWebAppV2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.WebPages;

namespace CatalcaliWebAppV2.Controllers
{
    public class CartController : Controller
    {
        private DataContext _context = null;


        // GET: Cart
        [Route("sepetim")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            Cart cart = GetCart();
            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("NoProductsFound", "Sepetinizde ürün bulunmamaktadır.");
            }
            return View(GetCart());
        }
        public JsonResult AddToCart(int ProductId)
        {
            using (_context = new DataContext())
            {
                Product product = _context.Products.FirstOrDefault(x => x.ProductId == ProductId);

                if (product != null)
                {
                    GetCart().AddProduct(product, 1);
                }
                return Json(product, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult RemoveFromCart(int Id)
        {
            using (_context = new DataContext())
            {
                Product product = _context.Products.FirstOrDefault(x => x.ProductId == Id);
                if (product != null)
                {
                    GetCart().DeleteProduct(product);
                }
                return RedirectToAction("Index");
            }
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        [ChildActionOnly]
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        [Route("siparis")]
        //[Authorize(Roles = "User,Admin")]
        public ActionResult Checkout()
        {
            Cart cart = new Cart();
            cart = GetCart();
            ViewData["Cart"] = cart;
            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("NoProductsFounds", "Sepetinizde ürün bulunmamaktadır.");
            }
            return View(new ShippingDetailsViewModel());
        }
        [HttpPost]
        [Route("siparis")]
        //[Authorize(Roles = "User,Admin")]
        public ActionResult Checkout(ShippingDetailsViewModel entity)
        {
            Cart cart = GetCart();
            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("NoProductsFound", "Sepetinizde ürün bulunmamaktadır.");
            }
            else if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);
                cart.Clear();
                return View("Completed", entity);
            }
            return View(entity);

        }
        private void SaveOrder(Cart cart, ShippingDetailsViewModel entity)
        {
            using (_context = new DataContext())
            {
                Order order = new Order();
                //üyelikli sipariş
                if (User.Identity.Name == null || User.Identity.Name == "")
                {
                    order.OrderNumber = "A" + (new Random()).Next(11111, 99999).ToString();
                    order.Total = cart.shipping;
                    order.OrderDate = DateTime.Now;
                    order.OrderState = EnumOrderState.Bekleyen;
                    order.Username = entity.Eposta;
                    order.İsim = entity.İsim;
                    order.Soyisim = entity.Soyisim;
                    order.AdresBasligi = entity.AdresBasligi;
                    order.Adres = entity.Adres;
                    order.Sehir = entity.Sehir;
                    order.İlce = entity.İlce;
                    order.Telefon = entity.Telefon;
                    order.Eposta = entity.Eposta;
                    order.PostaKodu = entity.PostaKodu;
                    order.OrderNote = entity.OrderNote;
                    order.Orderlines = new List<OrderLine>();
                }
                else //üyeliksiz sipariş
                {
                    order.OrderNumber = "A" + (new Random()).Next(11111, 99999).ToString();
                    order.Total = cart.shipping;
                    order.OrderDate = DateTime.Now;
                    order.OrderState = EnumOrderState.Bekleyen;
                    order.Username = User.Identity.Name;
                    order.İsim = entity.İsim;
                    order.Soyisim = entity.Soyisim;
                    order.AdresBasligi = entity.AdresBasligi;
                    order.Adres = entity.Adres;
                    order.Sehir = entity.Sehir;
                    order.İlce = entity.İlce;
                    order.Telefon = entity.Telefon;
                    order.Eposta = entity.Eposta;
                    order.PostaKodu = entity.PostaKodu;
                    order.OrderNote = entity.OrderNote;
                    order.Orderlines = new List<OrderLine>();
                }
                foreach (var pr in cart.CartLines)
                {
                    var orderline = new OrderLine();
                    orderline.Quantity = pr.Quantity;
                    orderline.Price = pr.Quantity * pr.Product.Price;
                    orderline.ProductId = pr.Product.ProductId;
                    orderline.ShippingId = 1;
                    order.Orderlines.Add(orderline);
                }
                _context.Orders.Add(order);
                _context.SaveChanges();

                SmtpClient client = new SmtpClient();
                client.Host = ConfigurationManager.AppSettings["EmailHost"].ToString();
                client.Port = 25;
                client.EnableSsl = false;
                client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Email"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());

                MailAddress from = new MailAddress(ConfigurationManager.AppSettings["Email"].ToString());
                string to = order.Eposta.ToString();
                MailMessage mail = new MailMessage(from.ToString(), to);
                mail.CC.Add(to);
                mail.Subject = "Çatalcalı Doğal Organik Gıda Sipariş Özetiniz";
                mail.Body = "<span style ='font-size:50px; font-color:green'>Siparişin Bize Ulaştı!</span><br>" +
                    "<span style ='font-size:20px'>Ödeme işlemi kapıda, Nakit veya Kredi Kartı ile gerçekleştireceğimizi unutma.<br>" +
                    "Siparişini en hızlı şekilde sana ulaştırmak için seni arayıp bir gönderim saatini seçmeni isteyeceğiz.</span><br>" +
                    "<span style='color: darkgrey; font-size:15px'>Çatalcalı Organik Doğal Gıdayı tercih ettiğiniz için teşekkür ederiz.</span>";
                mail.IsBodyHtml = true;
                client.Send(mail);
            }
        }
    }
}
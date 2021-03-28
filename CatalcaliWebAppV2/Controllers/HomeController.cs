using CatalcaliWebAppV2.Entities;
using CatalcaliWebAppV2.Models;
using CatalcaliWebAppV2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace CatalcaliWebAppV2.Controllers
{
    [RoutePrefix("anasayfa")]
    public class HomeController : Controller
    {
        DataContext _context = null;
        ProductRepository prodRep = new ProductRepository();
        CategoryRepository catRep = new CategoryRepository();

        int pageSize = 12;
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            DataContext db = new DataContext();

            var products = db.Products.OrderByDescending(x => x.ProductId)
            .Where(x => x.IsApproved && x.IsHome)
            .Select(x => new ProductModel()
            {
                ProductId = x.ProductId,
                Name = x.Name.Length > 50 ? x.Name.Substring(0, 40) + "..." : x.Name,
                Description = x.Description.Length > 50 ? x.Description.Substring(0, 40) + "..." : x.Description,
                Price = x.Price,
                Stock = x.Stock,
                Weight = x.Weight,
                Image = x.Image,
                ImageDescription = x.ImageDescription,
                CategoryId = x.CategoryId
            });
            return View(products.ToPagedList(page ,20));
        }

        [Route("urunler/detay/{name}-{id:int}")]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            using (_context = new DataContext())
            {
                Product prod = prodRep.GetById(id).ProccesResult;
                return View(prod);
            }
        }

        [Route("urunler/kategoriler/{id}")]
        [AllowAnonymous]
        public ActionResult List(int? id)
        {
            using (_context = new DataContext())
            {
                var products = prodRep.GetAll().ProccesResult
               .Where(x => x.IsApproved)
               .Select(x => new ProductModel()
               {
                   ProductId = x.ProductId,
                   Name = x.Name.Length > 50 ? x.Name.Substring(0, 40) + "..." : x.Name,
                   Description = x.Description.Length > 50 ? x.Description.Substring(0, 40) + "..." : x.Description,
                   Price = x.Price,
                   Stock = x.Stock,
                   Weight = x.Weight,
                   Image = x.Image,
                   ImageDescription = x.ImageDescription,
                   CategoryId = x.CategoryId,
                   Category = x.Category,

               }).AsQueryable();

                if (id != null)
                {
                    products = products.Where(x => x.CategoryId == id);
                }
                return View(products.ToList());
            }
        }
        [ChildActionOnly]
        public PartialViewResult GetCategories()
        {
            using (_context = new DataContext())
            {
                return PartialView(_context.Categories.ToList());
            }
        }

        [Route("iletisim")]
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }

        [Route("kapida-odeme")]
        [AllowAnonymous]
        public ActionResult PayAtTheDoor()
        {
            return View();
        }

        [Route("siparis-sureci")]
        [AllowAnonymous]
        public ActionResult OrderProcess()
        {
            return View();
        }

        [Route("servis-gunleri")]
        [AllowAnonymous]
        public ActionResult ServiceDays()
        {
            return View();
        }

        [Route("sss")]
        [AllowAnonymous]
        public ActionResult SSS()
        {
            return View();
        }
    }
}
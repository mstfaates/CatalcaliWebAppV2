using CatalcaliWebAppV2.Areas.Admin.Models;
using CatalcaliWebAppV2.Entities;
using CatalcaliWebAppV2.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CatalcaliWebAppV2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private DataContext _context = new DataContext();
        ProductRepository pr = new ProductRepository();
        CategoryRepository cr = new CategoryRepository();
        InstanceResult<Product> result = new InstanceResult<Product>();

        // GET: Admin/Product
        public ActionResult Index()
        {
            return View(pr.GetAll().ProccesResult.ToList());
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,Stock,Image,Weight,ImageDescription,IsHome,IsApproved,CategoryId")] Product product, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                string desc = product.ImageDescription;
                string photoName = "";
                if (photo != null && photo.ContentLength > 0)
                {
                    string ext = Path.GetExtension(photo.FileName);
                    photoName = photo.FileName.Replace(' ', '-').Replace(".jpeg", "").Replace(".jpg", "") + DateTime.Now.ToString().Replace(".", "").Replace(":", "").Replace(" ", "").Replace("AM", "").Replace("PM", "").Replace("/", "").Replace("\"","").Replace("-", "");
                    if (ext == ".jpg" || ext == ".jpeg")
                    {
                        photoName += ext;
                    }
                    else if (ext == ".png")
                    {
                        photoName += ext;
                    }
                    else if (ext == ".bmp")
                    {
                        photoName += ext;
                    }
                    else
                    {
                        ViewBag.Mesaj = "Lütfen .jpg, .png, .bmp tipinde resim yükleyiniz.";
                        return View(product);
                    }
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/Upload/Product/"), photoName);
                    photo.SaveAs(path);
                }
                product.Image = photoName;

                result.resultint = pr.Create(product);
                _context.SaveChanges();
                if (result.resultint.ProccesResult > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductViewModel pvm = new ProductViewModel();
            Product product = _context.Products.Find(id);
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            //pvm.Product = pr.GetById(id).ProccesResult;
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                string photoName = model.Image;
                if (photo != null && photo.ContentLength > 0)
                {
                    string ext = Path.GetExtension(photo.FileName);
                    photoName = photo.FileName.Replace(' ', '-').Replace(".jpeg", "").Replace(".jpg", "").Replace(".bmp", "").Replace(".svg", "").Replace(".png", "") + DateTime.Now.ToString().Replace(".", "").Replace(":", "").Replace(" ", "").Replace("/", "").Replace("\"", "").Replace("AM", "").Replace("PM", "");

                    if (ext == ".jpg" || ext == ".jpeg")
                    {
                        photoName += ext;
                    }
                    else if (ext == ".png")
                    {
                        photoName += ext;
                    }
                    else if (ext == ".bmp")
                    {
                        photoName += ext;
                    }
                    else if (ext == ".svg")
                    {
                        photoName += ext;
                    }
                    else
                    {
                        ViewBag.Mesaj = "Lütfen .jpg, .png, .bmp, .svg formatında resim yükleyiniz.";
                        return View(model);
                    }
                    string path = Server.MapPath("~/Areas/Admin/Upload/Product/" + photoName);
                    photo.SaveAs(path);
                }
                model.Image = photoName;

                result.resultint = pr.Update(model);
                if (result.resultint.ProccesResult > 0)
                {
                    return RedirectToAction("Index");
                }
                ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
                return View(model);
            }
            return View(model);

        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            result.resultint = pr.Delete(id);
            _context.SaveChanges();
            return RedirectToAction("Index", new { @m = result.resultint.Message, @id = id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _context != null)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Modal()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }
    }
}
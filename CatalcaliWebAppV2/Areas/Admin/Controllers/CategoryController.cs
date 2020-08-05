using CatalcaliWebAppV2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CatalcaliWebAppV2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private DataContext _context = null;

        // GET: Admin/Category
        public ActionResult Index()
        {
            using (_context = new DataContext())
            {
                return View(_context.Categories.ToList());
            }
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            using (_context = new DataContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Category category = _context.Categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description, CategoryImage")] Category category, HttpPostedFileBase photo)
        {
            using (_context = new DataContext())
            {
                if (ModelState.IsValid)
                {
                    if (photo != null)
                    {
                        string photoName = "";
                        if (photo != null && photo.ContentLength > 0)
                        {
                            string ext = Path.GetExtension(photo.FileName);
                            photoName = photo.FileName.Replace(' ', '-').Replace(".png", "").Replace(".svg", "") + DateTime.Now.ToString().Replace(".", "").Replace(":", "").Replace(" ", "");
                            if (ext == ".png")
                            {
                                photoName += ext;
                            }
                            else if (ext == ".svg")
                            {
                                photoName += ext;
                            }
                            else
                            {
                                ViewBag.Mesaj = "Lütfen .png ya da .svg formatında resim yükleyiniz.";
                                return View(category);
                            }
                            string path = Path.Combine(Server.MapPath("~/Areas/Admin/Upload/Icon/"), photoName);
                            photo.SaveAs(path);
                        }
                        category.CategoryImage = photoName;
                        _context.Categories.Add(category);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _context.Categories.Add(category);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                return View(category);
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            using (_context = new DataContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Category category = _context.Categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CategoryImage")] Category category, HttpPostedFileBase photo)
        {
            using (_context = new DataContext())
            {
                if (ModelState.IsValid)
                {
                    string photoName = "";
                    if (photo != null && photo.ContentLength > 0)
                    {
                        string ext = Path.GetExtension(photo.FileName);
                        photoName = photo.FileName.Replace(' ', '-').Replace(".svg", "").Replace(".png", "") + DateTime.Now.ToString().Replace(".", "").Replace(":", "").Replace(" ", "");
                        if (ext == ".png")
                        {
                            photoName += ext;
                        }
                        else if (ext == ".svg")
                        {
                            photoName += ext;
                        }
                        else
                        {
                            ViewBag.Mesaj = "Lütfen .jpg, .png, .bmp tipinde resim yükleyiniz.";
                            return View(category);
                        }
                        string path = Path.Combine(Server.MapPath("~/Areas/Admin/Upload/Icon/"), photoName);
                        photo.SaveAs(path);
                    }
                    category.CategoryImage = photoName;

                    _context.Entry(category).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(category);
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            using (_context = new DataContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Category category = _context.Categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (_context = new DataContext())
            {
                Category category = _context.Categories.Find(id);
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _context != null)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
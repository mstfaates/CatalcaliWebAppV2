using CatalcaliWebAppV2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CatalcaliWebAppV2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShippingController : Controller
    {
        private DataContext _context = new DataContext();

        public ActionResult Index()
        {
            using (_context = new DataContext())
            {
                return View(_context.Shippings.ToList());
            }
        }


        // GET: Admin/Shipping
        public ActionResult EditShipping(int? id)
        {
            using (_context = new DataContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Shipping shipping = _context.Shippings.Find(id);
                if (shipping == null)
                {
                    return HttpNotFound();
                }
                return View(shipping);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditShipping([Bind(Include = "ShippingId,ShippingName,ShippingDescription,ShippingFee")] Shipping shipping)
        {
            using (_context = new DataContext())
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(shipping).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(shipping);
            }
        }

        public ActionResult Delete(int? id)
        {
            using (_context = new DataContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Shipping shipping = _context.Shippings.Find(id);
                if (shipping == null)
                {
                    return HttpNotFound();
                }
                return View(shipping);
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (_context = new DataContext())
            {
                Shipping shipping = _context.Shippings.Find(id);
                _context.Shippings.Remove(shipping);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}
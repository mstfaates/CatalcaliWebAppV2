using CatalcaliWebAppV2.Models;
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
    public class ApplicationUserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ApplicationUsers
        public ActionResult UserList()
        {
            return View(db.Users.ToList());
        }

        // GET: Admin/ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }
        // GET: Admin/ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var applicationUser = db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }
        // POST: Admin/ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(ApplicationUser appuser)
        {
            ApplicationUser applicationUser = db.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("UserList");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
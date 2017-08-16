using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Survival.DAL;
using Survival.Models;

namespace Survival.Areas.Admin.Controllers
{
    public class LocationTypesController : Controller
    {
        private GameContext db = new GameContext();

        // GET: Admin/LocationTypes
        public ActionResult Index()
        {
            return View(db.LocationTypes.ToList());
        }

        // GET: Admin/LocationTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationType locationType = db.LocationTypes.Find(id);
            if (locationType == null)
            {
                return HttpNotFound();
            }
            return View(locationType);
        }

        // GET: Admin/LocationTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LocationTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] LocationType locationType)
        {
            if (ModelState.IsValid)
            {
                locationType.Id = Guid.NewGuid();
                db.LocationTypes.Add(locationType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locationType);
        }

        // GET: Admin/LocationTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationType locationType = db.LocationTypes.Find(id);
            if (locationType == null)
            {
                return HttpNotFound();
            }
            return View(locationType);
        }

        // POST: Admin/LocationTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] LocationType locationType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locationType);
        }

        // GET: Admin/LocationTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationType locationType = db.LocationTypes.Find(id);
            if (locationType == null)
            {
                return HttpNotFound();
            }
            return View(locationType);
        }

        // POST: Admin/LocationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            LocationType locationType = db.LocationTypes.Find(id);
            db.LocationTypes.Remove(locationType);
            db.SaveChanges();
            return RedirectToAction("Index");
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

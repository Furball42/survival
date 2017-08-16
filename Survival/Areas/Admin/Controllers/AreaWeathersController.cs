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
    public class AreaWeathersController : Controller
    {
        private GameContext db = new GameContext();

        // GET: Admin/AreaWeathers
        public ActionResult Index()
        {
            return View(db.Weathers.ToList());
        }

        // GET: Admin/AreaWeathers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaWeather areaWeather = db.Weathers.Find(id);
            if (areaWeather == null)
            {
                return HttpNotFound();
            }
            return View(areaWeather);
        }

        // GET: Admin/AreaWeathers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AreaWeathers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Image,ExposureModifier,ProbabilityValue")] AreaWeather areaWeather)
        {
            if (ModelState.IsValid)
            {
                areaWeather.Id = Guid.NewGuid();
                db.Weathers.Add(areaWeather);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(areaWeather);
        }

        // GET: Admin/AreaWeathers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaWeather areaWeather = db.Weathers.Find(id);
            if (areaWeather == null)
            {
                return HttpNotFound();
            }
            return View(areaWeather);
        }

        // POST: Admin/AreaWeathers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Image,ExposureModifier,ProbabilityValue")] AreaWeather areaWeather)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areaWeather).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(areaWeather);
        }

        // GET: Admin/AreaWeathers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaWeather areaWeather = db.Weathers.Find(id);
            if (areaWeather == null)
            {
                return HttpNotFound();
            }
            return View(areaWeather);
        }

        // POST: Admin/AreaWeathers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AreaWeather areaWeather = db.Weathers.Find(id);
            db.Weathers.Remove(areaWeather);
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

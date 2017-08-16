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
    public class AreaTemperaturesController : Controller
    {
        private GameContext db = new GameContext();

        // GET: Admin/AreaTemperatures
        public ActionResult Index()
        {
            return View(db.Temperatures.ToList());
        }

        // GET: Admin/AreaTemperatures/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaTemperature areaTemperature = db.Temperatures.Find(id);
            if (areaTemperature == null)
            {
                return HttpNotFound();
            }
            return View(areaTemperature);
        }

        // GET: Admin/AreaTemperatures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AreaTemperatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,ExposureModifier,ProbabilityValue")] AreaTemperature areaTemperature)
        {
            if (ModelState.IsValid)
            {
                areaTemperature.Id = Guid.NewGuid();
                db.Temperatures.Add(areaTemperature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(areaTemperature);
        }

        // GET: Admin/AreaTemperatures/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaTemperature areaTemperature = db.Temperatures.Find(id);
            if (areaTemperature == null)
            {
                return HttpNotFound();
            }
            return View(areaTemperature);
        }

        // POST: Admin/AreaTemperatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,ExposureModifier,ProbabilityValue")] AreaTemperature areaTemperature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areaTemperature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(areaTemperature);
        }

        // GET: Admin/AreaTemperatures/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaTemperature areaTemperature = db.Temperatures.Find(id);
            if (areaTemperature == null)
            {
                return HttpNotFound();
            }
            return View(areaTemperature);
        }

        // POST: Admin/AreaTemperatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AreaTemperature areaTemperature = db.Temperatures.Find(id);
            db.Temperatures.Remove(areaTemperature);
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

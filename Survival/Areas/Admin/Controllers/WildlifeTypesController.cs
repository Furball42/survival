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
    public class WildlifeTypesController : Controller
    {
        private GameContext db = new GameContext();

        // GET: Admin/WildlifeTypes
        public ActionResult Index()
        {
            return View(db.WildlifeTypes.ToList());
        }

        // GET: Admin/WildlifeTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WildlifeType wildlifeType = db.WildlifeTypes.Find(id);
            if (wildlifeType == null)
            {
                return HttpNotFound();
            }
            return View(wildlifeType);
        }

        // GET: Admin/WildlifeTypes/Create
        public ActionResult Create()
        {
            WildlifeTypeViewModel wildlifeTypeViewModel = new WildlifeTypeViewModel();

            var itemTypes = db.ItemTypes.ToList();
            wildlifeTypeViewModel.ItemTypes = itemTypes;

            return View(wildlifeTypeViewModel);
        }

        // POST: Admin/WildlifeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,FindChanceValue,BaseHuntValue,Icon")] WildlifeType wildlifeType)
        {
            if (ModelState.IsValid)
            {
                wildlifeType.Id = Guid.NewGuid();
                db.WildlifeTypes.Add(wildlifeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wildlifeType);
        }

        // GET: Admin/WildlifeTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WildlifeType wildlifeType = db.WildlifeTypes.Find(id);
            if (wildlifeType == null)
            {
                return HttpNotFound();
            }

            WildlifeTypeViewModel wildlifeTypeViewModel = new WildlifeTypeViewModel();
            var itemTypes = db.ItemTypes.ToList();

            wildlifeTypeViewModel.ItemTypes = itemTypes;
            wildlifeTypeViewModel.WildlifeType = wildlifeType;

            return View(wildlifeTypeViewModel);
        }

        // POST: Admin/WildlifeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,FindChanceValue,BaseHuntValue,Icon")] WildlifeType wildlifeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wildlifeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wildlifeType);
        }

        // GET: Admin/WildlifeTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WildlifeType wildlifeType = db.WildlifeTypes.Find(id);
            if (wildlifeType == null)
            {
                return HttpNotFound();
            }
            return View(wildlifeType);
        }

        // POST: Admin/WildlifeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            WildlifeType wildlifeType = db.WildlifeTypes.Find(id);
            db.WildlifeTypes.Remove(wildlifeType);
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

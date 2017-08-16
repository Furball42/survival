using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Survival.DAL;
using Survival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survival.Areas.Game.Controllers
{
    public class WildernessController : Controller
    {
        private GameContext db = new GameContext();
        public UserManager<ApplicationUser> UserManager { get; private set; }

        public WildernessController()
        {
            UserManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        // GET: Game/Wilderness
        public ActionResult Index()
        {
            return View();
        }

        // GET: Game/Wilderness/Details/5
        public ActionResult Details(Guid? id)
        {
            var character = db.Characters.Where(p => p.Id == id).FirstOrDefault();

            Wilderness wilderness = new Wilderness();
            wilderness.Character = character;
            wilderness.Area = character.Area;

            return View(wilderness);
        }

        //// GET: Game/Wilderness/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Game/Wilderness/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Game/Wilderness/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Game/Wilderness/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Game/Wilderness/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Game/Wilderness/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

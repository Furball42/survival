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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Script.Serialization;

namespace Survival.Areas.Game.Controllers
{
    public class CharactersController : Controller
    {
        private GameContext db = new GameContext();
        public UserManager<ApplicationUser> UserManager { get; private set; }

        public CharactersController()
        {
            UserManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        // GET: Game/Characters
        public ActionResult Index()
        {
            var user = UserManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var characters = db.Characters.Where(p => p.UserId == user.Id).ToList();
            return View(characters);
        }

        // GET: Game/Characters/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Game/Characters/Create
        public ActionResult Create()
        {
            CharacterCreateViewModel characterCreateViewModel = new CharacterCreateViewModel();

            return View(characterCreateViewModel);
        }

        // POST: Game/Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CharacterName,AreaName,")] CharacterCreateViewModel characterCreate)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

                Character newCharacter = new Character();

                newCharacter.Id = Guid.NewGuid();
                newCharacter.Day = 1;
                newCharacter.Time = new TimeSpan(8, 30, 0);
                newCharacter.StartTime = DateTime.Now;
                newCharacter.HealthValue = 100;
                newCharacter.HungerValue = 100;
                newCharacter.ThirstValue = 100;
                newCharacter.ExposureValue = 100;
                newCharacter.InventorySlotCount = 6;
                newCharacter.CharacterName = characterCreate.CharacterName;
                newCharacter.FoodResource = 0;
                newCharacter.WaterResource = 0;
                newCharacter.HideResource = 0;
                newCharacter.WoodResource = 0;
                newCharacter.Inventory = String.Empty;
                newCharacter.UserId = user.Id;

                db.Characters.Add(newCharacter);
                //db.SaveChanges();

                //add area
                Area newArea = new Area();
                newArea.Id = Guid.NewGuid();
                newArea.Description = characterCreate.AreaName;
                newArea.Data = String.Empty;

                AreaWeather weather = Helpers.EngineHelpers.GenerateWeather();
                newArea.Weather = weather;

                AreaTemperature temp = Helpers.EngineHelpers.GenerateTemperature();
                newArea.Temperature = temp;

                db.Areas.Add(newArea);

                //generate cabin
                CharacterAreaModel charArea = new CharacterAreaModel();
                List<Location> locations = new List<Location>();
                Location starterCabin = Helpers.EngineHelpers.GenerateStarterCabin();
                locations.Add(starterCabin);
                charArea.locations = locations;

                var json = new JavaScriptSerializer().Serialize(charArea);
                
                //db.SaveChanges();

                newCharacter.Area = newArea;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
            //return View(character);
        }

        // GET: Game/Characters/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Game/Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Day,Time,StartTime,HealthValue,ThristValue,HungerValue,ExposureValue,InventorySlotCount,CharacterName,FoodResource,WaterResource,WoodResource,HideResource")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(character);
        }

        // GET: Game/Characters/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Game/Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Character character = db.Characters.Find(id);
            db.Characters.Remove(character);
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

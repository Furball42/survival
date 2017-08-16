using Survival.DAL;
using Survival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survival.Helpers
{
    public class EngineHelpers
    {
        private static GameContext db = new GameContext();

        public static AreaWeather GenerateWeather()
        {
            AreaWeather newWeather = new AreaWeather();
            var weathers = db.Weathers.ToList();

            Random rnd = new Random();
            int r = rnd.Next(weathers.Count);
            newWeather = weathers[r];

            return newWeather;
        }

        public static AreaTemperature GenerateTemperature()
        {
            AreaTemperature newTemperature = new AreaTemperature();
            var temps = db.Temperatures.ToList();

            Random rnd = new Random();
            int r = rnd.Next(temps.Count);
            newTemperature = temps[r];

            return newTemperature;
        }

        public static Location GenerateStarterCabin()
        {
            var cabin = db.Locations.Where(p => p.isHomeCabin == true).FirstOrDefault();
            return cabin;
        }
    }
}
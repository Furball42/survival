using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Survival.Models
{
    public class Character
    {
        public Guid Id { get; set; }
        public int Day { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime StartTime { get; set; }
        public double HealthValue { get; set; }
        public double ThirstValue { get; set; }
        public double HungerValue { get; set; }
        public double ExposureValue { get; set; }
        public int InventorySlotCount { get; set; }        
        public string CharacterName { get; set; }
        public int FoodResource { get; set; }
        public int WaterResource { get; set; }
        public int WoodResource { get; set; }
        public int HideResource { get; set; }
        public string Inventory { get; set; }
        public string Gear { get; set; }
        public string CharacterPicture { get; set; }

        //flags

        public string UserId { get; set; }
        //public virtual ApplicationUser User { get; set; }
        public virtual Area Area { get; set; }
    }

    //not needed?
    public class Gear
    {
        public Guid HeadSlot { get; set; }
        public Guid TorsoSlot { get; set; }
        public Guid HandsSlot { get; set; }
        public Guid LegsSlot { get; set; }
        public Guid FeetSlot { get; set; }
        public Guid Accessory1Slot { get; set; }
        public Guid Accessory2Slot { get; set; }
        public Guid Bag { get; set; }
    }

    public class Area
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }        

        public virtual AreaWeather Weather { get; set; }
        public virtual AreaTemperature Temperature { get; set; }
    }
}
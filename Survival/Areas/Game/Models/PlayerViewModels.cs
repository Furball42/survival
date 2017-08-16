using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survival.Models
{
    public class CharacterCreateViewModel
    {
        public string CharacterName { get; set; }
        public string AreaName { get; set; }
    }

    public class Wilderness
    {
        public Character Character { get; set; }
        public Area Area { get; set; }
        public Gear Gear { get; set; }
    }

    public class CharacterAreaModel
    {
        public List<Location> locations = new List<Location>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survival.Models
{
    public class WildlifeTypeViewModel
    {
        public WildlifeType WildlifeType { get; set; }
        public IEnumerable<ItemType> ItemTypes { get; set; }

        public List<ItemType> SelectedItemTypes { get; set; }
    }
}
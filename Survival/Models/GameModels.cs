using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survival.Models
{
    public class InventorySlot
    {
        public Guid Id { get; set; }
        public Guid Item { get; set; }
    }

    public class Item
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int ConditionValue { get; set; }

        virtual public ItemType Type { get; set; }
        virtual public RarityType Rarity { get; set; }
    }

    public class ItemType
    {
        public ItemType()
        {
            this.WildlifeTypes = new HashSet<WildlifeType>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WildlifeType> WildlifeTypes { get; set; }
    }

    public class RarityType
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }

    public class Wildlife
    {
        public Guid TypeId { get; set; }
    }

    public class WildlifeType
    {
        public WildlifeType()
        {
            this.ItemTypes = new HashSet<ItemType>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public int FindChanceValue { get; set; }
        public int BaseHuntValue { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<ItemType> ItemTypes { get; set; }
    }

    public class Location
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int FindChanceValue { get; set; }
        public string Icon { get; set; }
        public bool isHomeCabin { get; set; }
        public bool isSearched { get; set; }

        public Guid TypeId { get; set; }
    }

    public class LocationType
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ItemType> LootableItemtypes { get; set; }
    }

    public class AreaWeather
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double ExposureModifier { get; set; }
        public int ProbabilityValue { get; set; }
    }

    public class AreaTemperature
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public double ExposureModifier { get; set; }
        public int ProbabilityValue { get; set; }
    }

}
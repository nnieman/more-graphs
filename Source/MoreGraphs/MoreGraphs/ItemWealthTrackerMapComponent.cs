using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs
{
    public class ItemWealthTrackerMapComponent : MapComponent
    {
        private Dictionary<string, WealthCategory> thingCategoryMap;

        private Dictionary<WealthCategory, float> latestItemWealthByCategory;

        private int lastUpdatedTick = -100000;
        private const int cacheTickInterval = 5000;

        public ItemWealthTrackerMapComponent(Map map) : base(map)
        {
            thingCategoryMap = GetThingCategoyMap();
        }

        public Dictionary<WealthCategory, float> ItemWealthByCategory
        {
            get
            {
                if (Find.TickManager.TicksGame - lastUpdatedTick > cacheTickInterval)
                {
                    lastUpdatedTick = Find.TickManager.TicksGame;
                    latestItemWealthByCategory = GetWealthByCategory();
                }

                return latestItemWealthByCategory;
            }
        }

        private Dictionary<WealthCategory, float> GetWealthByCategory()
        {
            // Initialize wealth categories
            Dictionary<WealthCategory, float> wealthByCategory = new Dictionary<WealthCategory, float>();

            foreach (WealthCategory wealthCategory in Enum.GetValues(typeof(WealthCategory)))
            {
                wealthByCategory[wealthCategory] = 0f;
            }

            // Get all player items
            List<Thing> allPlayerThings = new List<Thing>();
            ThingOwnerUtility.GetAllThingsRecursively(map, ThingRequest.ForGroup(ThingRequestGroup.HaulableEver), allPlayerThings, allowUnreal: false, delegate (IThingHolder thingHolder)
            {
                bool isPlayerThingHolder = true;

                if (thingHolder is MapComponent)
                {
                    isPlayerThingHolder = false;
                }
                else if (thingHolder is PassingShip)
                {
                    isPlayerThingHolder = false;
                }
                else
                {
                    Pawn thingHolderAsPawn = thingHolder as Pawn;
                    if (thingHolderAsPawn != null)
                    {
                        if (thingHolderAsPawn.Faction != Faction.OfPlayer)
                        {
                            isPlayerThingHolder = false;
                        }
                    }
                }

                return isPlayerThingHolder;
            });

            // Classify and tabulate by wealth category
            foreach (var thing in allPlayerThings)
            {
                if (thing.SpawnedOrAnyParentSpawned && !thing.PositionHeld.Fogged(map))
                {
                    var wealthCategory = GetWealthCategory(thing.def.FirstThingCategory);

                    wealthByCategory[wealthCategory] += thing.MarketValue * thing.stackCount;
                }
            }

            return wealthByCategory;
        }

        private WealthCategory GetWealthCategory(ThingCategoryDef thingCategoryDef)
        {
            while (thingCategoryDef != null)
            {
                if (thingCategoryMap.ContainsKey(thingCategoryDef.defName))
                {
                    return thingCategoryMap[thingCategoryDef.defName];
                }

                thingCategoryDef = thingCategoryDef.parent;
            }

            return WealthCategory.Other;
        }

        private Dictionary<string, WealthCategory> GetThingCategoyMap()
        {
            return new Dictionary<string, WealthCategory>
            {
                ["Foods"] = WealthCategory.Food,
                ["Apparel"] = WealthCategory.Clothing_Armor,
                ["BodyParts"] = WealthCategory.Medical_Drugs,
                ["Medicine"] = WealthCategory.Medical_Drugs,
                ["Drugs"] = WealthCategory.Medical_Drugs,
                ["ResourcesRaw"] = WealthCategory.Materials,
                ["Textiles"] = WealthCategory.Materials,
                ["Corpses"] = WealthCategory.Materials,
                ["Weapons"] = WealthCategory.Weapons,
                ["Manufactured"] = WealthCategory.Manufactured,
                ["Buildings"] = WealthCategory.Manufactured,
                ["Items"] = WealthCategory.Manufactured
            };
        }
    }
}

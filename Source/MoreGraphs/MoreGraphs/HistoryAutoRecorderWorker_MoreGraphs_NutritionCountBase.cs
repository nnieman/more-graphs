using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs
{
    class HistoryAutoRecorderWorker_MoreGraphs_NutritionCountBase : HistoryAutoRecorderWorker
    {
        private ThingCategoryDef thingCategoryDef;

        public HistoryAutoRecorderWorker_MoreGraphs_NutritionCountBase(ThingCategoryDef thingCategoryDef) : base()
        {
            this.thingCategoryDef = thingCategoryDef;
        }

        public override float PullRecord()
        {
            float totalNutrition = 0f;
            
            foreach(Map map in Find.Maps)
            {
                if (map.IsPlayerHome)
                {
                    Dictionary<ThingDef, int> allResources = map.resourceCounter.AllCountedAmounts;

                    foreach(KeyValuePair<ThingDef, int> thingDef in allResources)
                    {
                        if (thingDef.Key.IsWithinCategory(this.thingCategoryDef))
                        {
                            float thingNutrition = thingDef.Key.GetStatValueAbstract(StatDefOf.Nutrition);

                            totalNutrition += thingNutrition * thingDef.Value;
                        }
                    }
                }
            }

            return totalNutrition;
        }
    }
}

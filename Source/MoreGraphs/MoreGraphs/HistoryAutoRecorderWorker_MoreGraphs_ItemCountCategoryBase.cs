using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs
{
    class HistoryAutoRecorderWorker_MoreGraphs_ItemCountCategoryBase : HistoryAutoRecorderWorker
    {
        private ThingCategoryDef thingCategory;

        public HistoryAutoRecorderWorker_MoreGraphs_ItemCountCategoryBase(ThingCategoryDef thingCategoryDef) : base()
        {
            this.thingCategory = thingCategoryDef;
        }

        public override float PullRecord()
        {
            int totalCount = 0;
            
            foreach(Map map in Find.Maps)
            {
                if (map.IsPlayerHome)
                {
                    Dictionary<ThingDef, int> allResources = map.resourceCounter.AllCountedAmounts;

                    foreach (ThingDef thingDef in allResources.Keys)
                    {
                        if (thingDef.IsWithinCategory(thingCategory))
                        {
                            totalCount += allResources[thingDef];
                        }
                    }
                }
            }

            return totalCount;
        }
    }
}

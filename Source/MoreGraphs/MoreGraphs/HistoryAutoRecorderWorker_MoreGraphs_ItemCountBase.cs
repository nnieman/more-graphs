using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs
{
    class HistoryAutoRecorderWorker_MoreGraphs_ItemCountBase : HistoryAutoRecorderWorker
    {
        private ThingDef thingDef;

        public HistoryAutoRecorderWorker_MoreGraphs_ItemCountBase(ThingDef thingDef) : base()
        {
            this.thingDef = thingDef;
        }

        public override float PullRecord()
        {
            int totalCount = 0;
            
            foreach(Map map in Find.Maps)
            {
                if (map.IsPlayerHome)
                {
                    Dictionary<ThingDef, int> allResources = map.resourceCounter.AllCountedAmounts;

                    totalCount += allResources[this.thingDef];
                }
            }

            return totalCount;
        }
    }
}

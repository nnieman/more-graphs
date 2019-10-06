using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs
{
    class HistoryAutoRecorderWorker_MoreGraphsWealthCategoryBase : HistoryAutoRecorderWorker
    {
        private WealthCategory wealthCategory;

        public HistoryAutoRecorderWorker_MoreGraphsWealthCategoryBase(WealthCategory wealthCategory) : base()
        {
            this.wealthCategory = wealthCategory;
        }

        public override float PullRecord()
        {
            float totalWealth = 0f;
            
            foreach(Map map in Find.Maps)
            {
                if (map.IsPlayerHome)
                {
                    Dictionary<WealthCategory, float> wealthMap = map.GetComponent<ItemWealthTrackerMapComponent>().ItemWealthByCategory;

                    totalWealth += wealthMap[this.wealthCategory];
                }
            }

            return totalWealth;
        }
    }
}

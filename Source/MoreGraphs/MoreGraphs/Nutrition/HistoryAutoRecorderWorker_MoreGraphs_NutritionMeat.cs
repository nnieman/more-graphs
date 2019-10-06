using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs.Nutrition
{
    class HistoryAutoRecorderWorker_MoreGraphs_NutritionMeat : HistoryAutoRecorderWorker_MoreGraphs_NutritionCountBase
    {
        public HistoryAutoRecorderWorker_MoreGraphs_NutritionMeat() : base(ThingCategoryDefOf.MeatRaw)
        {
        }
    }
}

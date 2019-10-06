using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs.Nutrition
{
    class HistoryAutoRecorderWorker_MoreGraphs_NutritionVeg : HistoryAutoRecorderWorker_MoreGraphs_NutritionCountBase
    {
        public HistoryAutoRecorderWorker_MoreGraphs_NutritionVeg() : base(ThingCategoryDefOf.PlantFoodRaw)
        {
        }
    }
}

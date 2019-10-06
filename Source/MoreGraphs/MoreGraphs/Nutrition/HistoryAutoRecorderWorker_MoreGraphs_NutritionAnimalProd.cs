using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs.Nutrition
{
    class HistoryAutoRecorderWorker_MoreGraphs_NutritionAnimalProd : HistoryAutoRecorderWorker_MoreGraphs_NutritionCountBase
    {
        public HistoryAutoRecorderWorker_MoreGraphs_NutritionAnimalProd() : base(ThingCategoryDef.Named("AnimalProductRaw"))
        {
        }
    }
}

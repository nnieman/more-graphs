using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs.Manufactured
{
    class HistoryAutoRecorderWorker_MoreGraphs_Manufactured_Drugs : HistoryAutoRecorderWorker_MoreGraphs_ItemCountCategoryBase
    {
        public HistoryAutoRecorderWorker_MoreGraphs_Manufactured_Drugs() : base(ThingCategoryDefOf.Drugs)
        {
        }
    }
}

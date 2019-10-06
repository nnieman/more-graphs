using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs.Manufactured
{
    class HistoryAutoRecorderWorker_MoreGraphs_Manufactured_Medicine : HistoryAutoRecorderWorker_MoreGraphs_ItemCountCategoryBase
    {
        public HistoryAutoRecorderWorker_MoreGraphs_Manufactured_Medicine() : base(ThingCategoryDefOf.Medicine)
        {
        }
    }
}

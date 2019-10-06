using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs.Materials
{
    class HistoryAutoRecorderWorker_MoreGraphs_Materials_Wood : HistoryAutoRecorderWorker_MoreGraphs_ItemCountBase
    {
        public HistoryAutoRecorderWorker_MoreGraphs_Materials_Wood() : base(ThingDefOf.WoodLog)
        {
        }
    }
}

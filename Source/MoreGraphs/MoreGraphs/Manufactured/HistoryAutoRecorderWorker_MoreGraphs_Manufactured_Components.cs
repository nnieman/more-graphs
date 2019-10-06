using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs.Manufactured
{
    class HistoryAutoRecorderWorker_MoreGraphs_Manufactured_Components : HistoryAutoRecorderWorker_MoreGraphs_ItemCountBase
    {
        public HistoryAutoRecorderWorker_MoreGraphs_Manufactured_Components() : base(ThingDefOf.ComponentIndustrial)
        {
        }
    }
}

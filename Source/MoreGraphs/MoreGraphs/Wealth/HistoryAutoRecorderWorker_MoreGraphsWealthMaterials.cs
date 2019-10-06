using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs.Wealth
{
    class HistoryAutoRecorderWorker_MoreGraphsWealthMaterials : HistoryAutoRecorderWorker_MoreGraphsWealthCategoryBase
    {
        public HistoryAutoRecorderWorker_MoreGraphsWealthMaterials() : base(WealthCategory.Materials)
        {
        }
    }
}

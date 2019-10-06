using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs.Wealth
{
    class HistoryAutoRecorderWorker_MoreGraphsWealthFood : HistoryAutoRecorderWorker_MoreGraphsWealthCategoryBase
    {
        public HistoryAutoRecorderWorker_MoreGraphsWealthFood() : base(WealthCategory.Food)
        {
        }
    }
}

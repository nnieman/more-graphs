using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs.Wealth
{
    class HistoryAutoRecorderWorker_MoreGraphsWealthManufactured : HistoryAutoRecorderWorker_MoreGraphsWealthCategoryBase
    {
        public HistoryAutoRecorderWorker_MoreGraphsWealthManufactured() : base(WealthCategory.Manufactured)
        {
        }
    }
}

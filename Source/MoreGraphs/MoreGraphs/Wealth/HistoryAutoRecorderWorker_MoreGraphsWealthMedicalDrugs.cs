using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs.Wealth
{
    class HistoryAutoRecorderWorker_MoreGraphsWealthMedicalDrugs : HistoryAutoRecorderWorker_MoreGraphsWealthCategoryBase
    {
        public HistoryAutoRecorderWorker_MoreGraphsWealthMedicalDrugs() : base(WealthCategory.Medical_Drugs)
        {
        }
    }
}

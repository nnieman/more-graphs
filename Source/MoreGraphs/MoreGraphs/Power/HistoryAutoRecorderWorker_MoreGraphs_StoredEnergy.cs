using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs.Power
{
    public class HistoryAutoRecorderWorker_MoreGraphs_StoredEnergy : HistoryAutoRecorderWorker
    {
        public override float PullRecord()
        {
            float totalPower = 0f;
            
            foreach(Map map in Find.Maps)
            {
                if (map.IsPlayerHome)
                {
                    foreach (PowerNet powerNet in map.powerNetManager.AllNetsListForReading)
                    {
                        totalPower += powerNet.CurrentStoredEnergy();
                    }
                }
            }

            return totalPower;
        }
    }
}

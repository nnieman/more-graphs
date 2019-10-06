using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs.Power
{
    public class HistoryAutoRecorderWorker_MoreGraphs_EnergyGainRate : HistoryAutoRecorderWorker
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
                        totalPower += powerNet.CurrentEnergyGainRate() / CompPower.WattsToWattDaysPerTick;
                    }
                }
            }

            return totalPower;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreGraphs
{
    public class MoreGraphsGameComponent : GameComponent
    {
        public MoreGraphsGameComponent(Game game) : base()
        {

        }

        public override void LoadedGame()
        {
            base.LoadedGame();
            FixHistoryRecorderGroups();
        }

        private void FixHistoryRecorderGroups()
        {
            int maxRecorderTicks = 0;

            foreach (HistoryAutoRecorderGroup historyAutoRecorderGroup in Find.History.Groups())
            {
                foreach (HistoryAutoRecorder historyAutoRecorder in historyAutoRecorderGroup.recorders)
                {
                    int ticks = historyAutoRecorder.records.Count * historyAutoRecorder.def.recordTicksFrequency;

                    if (ticks > maxRecorderTicks)
                    {
                        maxRecorderTicks = ticks;
                    }
                }
            }

            foreach (HistoryAutoRecorderGroup historyAutoRecorderGroup in Find.History.Groups())
            {
                foreach (HistoryAutoRecorder historyAutoRecorder in historyAutoRecorderGroup.recorders)
                {
                    int ticks = historyAutoRecorder.records.Count * historyAutoRecorder.def.recordTicksFrequency;
                    int missingTicks = maxRecorderTicks - ticks;
                    int missingRecords = missingTicks / historyAutoRecorder.def.recordTicksFrequency;

                    List<float> recordsCopy = historyAutoRecorder.records.ListFullCopy();
                    historyAutoRecorder.records.Clear();
                    historyAutoRecorder.records.AddRange(Enumerable.Repeat(0f, missingRecords));
                    historyAutoRecorder.records.AddRange(recordsCopy);
                }
            }
        }
    }
}

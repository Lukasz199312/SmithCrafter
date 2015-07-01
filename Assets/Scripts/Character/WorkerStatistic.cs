using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Character
{
    class WorkerStatistic : BasicStatistics
    {
        public float ChanceToExtraWeaponLevel { get; set; }
        public float MiningBonusRate { get; set; }
        public float WorkerExperince { get; set; }

        public WorkerStatistic getWorkerStatistic()
        {
            return this;
        }
    }
}

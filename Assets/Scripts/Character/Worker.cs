using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Character
{
    class Worker : WorkerStatistic, CharacterAction
    {
        public object getStatistic()
        {
            return (WorkerStatistic)getWorkerStatistic();
        }

        public object getObject()
        {
            return (Worker)this;
        }
    }
}

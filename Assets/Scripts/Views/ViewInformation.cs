using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Character;

namespace Assets.Scripts.Views
{
    class ViewInformation
    {
        public enum ViewType
        {
            CRAFT_VIEW,
            MINE_VIEW
        };

        public int WorkerSlots { get; set; }
        public ViewType type { get; set; }
    }
}

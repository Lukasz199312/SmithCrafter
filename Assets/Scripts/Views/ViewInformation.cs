using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Views
{
    public class ViewInformation
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

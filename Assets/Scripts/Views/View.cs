using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Views
{
    class View : MonoBehaviour
    {
        public ViewInformation.ViewType type;
        public ViewInformation Information = new ViewInformation();
        public WorkStation[] WorkStations;
        public GameObject WorkerObject;
        public GameObject WorkStation;

        void Start()
        {
            Information.type = type;

            foreach (WorkStation SingleWorkStataion in WorkStations)
            {
                switch (type)
                {
                    case ViewInformation.ViewType.CRAFT_VIEW:
                        GameObject Worker = null;
                        switch (SingleWorkStataion.mode)
                        {
                            case global::WorkStation.Mode.TO_SELL:
                                    Worker = Instantiate(WorkStation, SingleWorkStataion.transform.position, Quaternion.identity) as GameObject;
                                break;

                            case global::WorkStation.Mode.ACTIVE:
                                    Worker = Instantiate(WorkerObject, SingleWorkStataion.transform.position, Quaternion.identity) as GameObject;
                                break;
                        }
                        Worker.transform.parent = this.transform;
                        break;
                }
            }
        }

    }
}

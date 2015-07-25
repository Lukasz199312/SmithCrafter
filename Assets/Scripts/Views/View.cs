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
        public bool IsActive;

        void Start()
        {
            Information.type = type;

            foreach (WorkStation SingleWorkStataion in WorkStations)
            {
                for (int i = 0; i < PlayerData.Workstation.Length; i++)
                {
                    if (PlayerData.Workstation[i].ID == SingleWorkStataion.ID)
                    {
                        if (PlayerData.Workstation[i].mode != SingleWorkStataion.mode)
                        {
                            SingleWorkStataion.mode = PlayerData.Workstation[i].mode;
                            SetWorkStationMode(type, SingleWorkStataion);
                        }
                        else
                        {
                            SetWorkStationMode(type, SingleWorkStataion);
                        }
                       
                        break;
                    }

                }
            }
        }

        private void SetWorkStationMode(ViewInformation.ViewType type, WorkStation SingleWorkStation)
        {
            switch (type)
            {
                case ViewInformation.ViewType.CRAFT_VIEW:
                    GameObject Worker = null;
                    switch (SingleWorkStation.mode)
                    {
                        case global::WorkStation.Mode.TO_SELL:
                            Worker = Instantiate(WorkStation, SingleWorkStation.transform.position, Quaternion.identity) as GameObject;
                            break;

                        case global::WorkStation.Mode.ACTIVE:
                            Worker = Instantiate(WorkerObject, SingleWorkStation.transform.position, Quaternion.identity) as GameObject;
                            break;
                    }
                    Worker.transform.parent = this.transform;
                    break;
            }
        }

    }
}

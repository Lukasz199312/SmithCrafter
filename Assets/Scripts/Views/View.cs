using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Views
{
    public class View : MonoBehaviour
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
                SetWorkStationMode(type, SingleWorkStataion);
            }
        }

        private void SetWorkStationMode(ViewInformation.ViewType type, WorkStation SingleWorkStation)
        {
            CopyValues Copy = new CopyValues();
            switch (type)
            {
                case ViewInformation.ViewType.CRAFT_VIEW:
                    GameObject Worker = null;
                    switch (SingleWorkStation.mode)
                    {
                        case global::WorkStation.Mode.TO_SELL:

                            Copy.CopyScale(SingleWorkStation.transform, WorkStation.transform, transform);
                            Copy.CopySpriteRender(SingleWorkStation._SpriteRender, WorkStation.GetComponent<SpriteRenderer>());
                            Copy.CopyBoxCollider2D(SingleWorkStation._boxCollider2D, WorkStation.GetComponent<BoxCollider2D>());
                            
                            break;

                        case global::WorkStation.Mode.ACTIVE:
                            
                            Copy.CopyScale(SingleWorkStation.transform, WorkerObject.transform, transform);
                            Copy.CopySpriteRender(SingleWorkStation._SpriteRender, WorkerObject.GetComponent<SpriteRenderer>());
                            Copy.CopyBoxCollider2D(SingleWorkStation._boxCollider2D, WorkerObject.GetComponent<BoxCollider2D>());

                            break;
                    }
                    break;
            }
        }


    }
}

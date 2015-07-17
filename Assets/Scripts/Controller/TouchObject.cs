using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class TouchObject
    {
        public bool Enabled { get; set; }
        public GameObject SelectedGameObject { get; private set; }
        public bool IsTouched { get; private set; }
        public LayerMask Mask { get; set; }

        public TouchObject()
        {
            Enabled = true;
        }

        public void setPhase(Touch touch)
        {
            if (!Enabled) return;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    IsTouched = true;
                    break;

                case TouchPhase.Moved:
                    IsTouched = false;
                    break;

                case TouchPhase.Ended:
                    if(IsTouched) SelectedGameObject = DetectTouchOnGameObject(touch);
                    break;
            }
        }

        private GameObject DetectTouchOnGameObject(Touch touch)
        {
          //  Mask = 1 << 5;
            Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
            if (Physics2D.Raycast(pos, Vector2.up, 0, 10, Mask) == true) Debug.Log("Its Work");
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0, Mask);
            if (hit != null && hit.collider != null)
            {
                Debug.Log("I'm hitting " + hit.collider.name);
                return hit.collider.gameObject;
            }
            else return null;
        }

        public void UntachedObject()
        {
            SelectedGameObject = null;
        }
    }
}

using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Controller
{
    public class SwapAction
    {
        public Vector2 BeganPosition { get; private set; }
        public Vector2 EndPosition { get; private set; }
        public TouchPhase Phase { get; private set; }
        public bool Enabled { get; set; }
        private bool Move = false;
        private float Distance;

        public SwapAction(float Distance)
        {
            this.Distance = Distance;
            Enabled = true;
        }

        public void setPhase(Touch touch)
        {
            if (!Enabled) return;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    BeganPosition = touch.position;
                    Phase = touch.phase;
                    break;

                case TouchPhase.Ended:
                    if (Phase != TouchPhase.Began) break;
                    EndPosition = touch.position;
                    float Goal = Mathf.Abs(BeganPosition.x - EndPosition.x);
                    if (Goal >= Distance) Move = true;
                    break;

                case TouchPhase.Canceled:

                    break;
            }
        }

        public bool isMoving()
        {
            return Move;
        }

        public void FinishMove()
        {
            Move = false;
        }
    }
}

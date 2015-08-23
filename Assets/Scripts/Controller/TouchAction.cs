using UnityEngine;
using System.Collections;
using Assets.Scripts.Controller;
using UnityEngine.EventSystems;

public class TouchAction : MonoBehaviour {

    public SwapAction Swap { get; private set; }
    public TouchObject Touch { get; private set; }
    public LayerMask Mask;
    public float Distance;

	// Use this for initialization
	void Start () {
        Swap = new SwapAction(Distance);
        Touch = new TouchObject();
        Touch.Mask = Mask;
	}
	
	// Update is called once per frame
	void Update () {

        foreach (Touch touch in Input.touches)
        {
            if (Swap.Enabled)
            {
                Swap.setPhase(touch);
                if (Swap.isMoving() == true) Touch.Enabled = false;
            }

            if (Touch.Enabled)
            {
                Touch.setPhase(touch);
                if (Touch.SelectedGameObject != null) Swap.Enabled = false;
            }
        }

        if (Swap.isMoving() == false) Touch.Enabled = true;
	}

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeView : MonoBehaviour {

    public ViewsManager Manager;

    private Camera camera;
    private float CameraMoveSpeed;
    private System.DateTime Time;
    private GameObject[] Views;
    private TouchAction.Direction StartMoving = TouchAction.Direction.NO_DETECTED_MOVE;

	// Use this for initialization
	void Start () {
        Views = Manager.Views;
        CameraMoveSpeed = Manager.CameraMoveSpeed;
        camera = Manager.camera;
	}
	
	// Update is called once per frame
	void Update () {
        if (Manager.Touch_Action.MoveDirection != TouchAction.Direction.NO_DETECTED_MOVE)
        {
            TouchAction.Direction Direction = Manager.Touch_Action.MoveDirection;

            switch (Direction)
            {
                case TouchAction.Direction.LEFT:
                    MoveRight();
                    break;
                case TouchAction.Direction.RIGHT:
                    MoveLeft();
                    break;

            }

            Debug.Log(Manager.Touch_Action.MoveDirection);
        }
        else 
        switch (StartMoving)
        {
            case TouchAction.Direction.LEFT:
                float Goal = Vector2.Distance(camera.transform.position, Views[Manager.CurrentView - 1].transform.position);
                if (Goal > 0)
                {
                    float Camera_Z = camera.transform.position.z;

                    camera.transform.position
                        = Vector2.MoveTowards(camera.transform.position, Views[Manager.CurrentView - 1].transform.position, CameraMoveSpeed);
                    camera.transform.position.Set(camera.transform.position.x, camera.transform.position.y, -10);
                    camera.transform.position = new Vector3(camera.transform.position.x,
                                                            camera.transform.position.y,
                                                            Camera_Z);
                }
                else
                {
                    StartMoving = TouchAction.Direction.NO_DETECTED_MOVE;
                    Manager.CurrentView = Manager.CurrentView - 1;

                    Manager.Touch_Action.Swap = TouchAction.SwapState.ENABLED;
                }
                break;

            case TouchAction.Direction.RIGHT:
                Debug.Log("Move Right");
                Goal = Vector2.Distance(camera.transform.position, Views[Manager.CurrentView + 1].transform.position);
                if (Goal > 0)
                {
                    float Camera_Z = camera.transform.position.z;
                    camera.transform.position
                        = Vector2.MoveTowards(camera.transform.position, Views[Manager.CurrentView + 1].transform.position, CameraMoveSpeed);
                    camera.transform.position.Set(camera.transform.position.x, camera.transform.position.y, -10);
                    camera.transform.position = new Vector3(camera.transform.position.x,
                                         camera.transform.position.y,
                                         Camera_Z);
                }
                else
                {
                    StartMoving = TouchAction.Direction.NO_DETECTED_MOVE;
                    Manager.CurrentView = Manager.CurrentView + 1;
                    Manager.Touch_Action.Swap = TouchAction.SwapState.ENABLED;
                }
                break;
        }
	}

    private void MoveLeft()
    {
        if (Manager.CurrentView - 1 >= 0)
        {
            StartMoving = TouchAction.Direction.LEFT;
        }

        Time = Time.AddSeconds(Manager.Delay);
    }

    private void MoveRight()
    {
        if (Manager.CurrentView + 1 < Views.Length)
        {
            StartMoving = TouchAction.Direction.RIGHT;
            Time = Time.AddSeconds(Manager.Delay);
        }
    }
}

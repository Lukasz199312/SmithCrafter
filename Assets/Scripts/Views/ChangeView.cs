using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeView : MonoBehaviour {

    public ViewsManager Manager;

    private Camera camera;
    private float CameraMoveSpeed;
    private bool isMoved = false;
    private GameObject[] Views;
    private Vector2[] Touches;
    private DropMenu dropmenu;

	// Use this for initialization
	void Start () {
        Views = Manager.Views;
        CameraMoveSpeed = Manager.CameraMoveSpeed;
        camera = Manager.camera;
        isMoved = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (Manager.Touch_Action.Swap.isMoving() && !isMoved)
        {
            if (Manager.Touch_Action.Swap.BeganPosition.x < Manager.Touch_Action.Swap.EndPosition.x)
            {
                if (Manager.CurrentView - 1 >= 0)
                {
                    Manager.CurrentView --;
                    isMoved = true;
                }
            }
            else
            {
                if (Manager.CurrentView + 1 <= Views.Length - 1) 
                {
                     Manager.CurrentView ++;
                    isMoved = true;

                }
            }
        }
        else if (isMoved == true)
        {
            float goal = Vector2.Distance(camera.transform.position, Views[Manager.CurrentView].transform.position);
            if (goal > 0)
            {
                Vector3 NextMove = Views[Manager.CurrentView].transform.position;
                Vector3 Move = Vector3.MoveTowards(camera.transform.position, new Vector3(NextMove.x,
                                                                                          NextMove.y,
                                                                                          camera.transform.position.z),
                                                                                          CameraMoveSpeed);
                camera.transform.position = new Vector3(Move.x, Move.y, Move.z);
            }
            else
            {
                Manager.Touch_Action.Swap.FinishMove();
                isMoved = false;
            }
        }

	}

    private void MoveLeft()
    {
    }

    private void MoveRight()
    {
    }
}

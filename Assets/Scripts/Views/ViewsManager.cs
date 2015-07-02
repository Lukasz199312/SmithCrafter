using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewsManager : MonoBehaviour {

  // public List<GameObject> Views = new List<GameObject>();
   public GameObject[] Views;
   public TouchAction Touch_Action;
   public int CurrentView { get; private set; }
   public float CameraMoveSpeed;
   public Camera camera;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Touch_Action.MoveDirection != TouchAction.Direction.NO_DETECTED_MOVE)
        {
            Debug.Log(Touch_Action.MoveDirection);
        }
	}
}

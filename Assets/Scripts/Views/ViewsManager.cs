using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewsManager : MonoBehaviour {

  // public List<GameObject> Views = new List<GameObject>();
   public GameObject[] Views;
   public ChangeView Changeview;
   public TouchAction Touch_Action;
   public int CurrentView;
 
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Touch_Action.GetLastDirection() != TouchAction.Direction.NO_DETECTED_MOVE)
        {
            Changeview.Change(Views, Touch_Action.GetLastDirection(),ref CurrentView);
            Touch_Action.ResetPhaseDirection();
        }
	}
}

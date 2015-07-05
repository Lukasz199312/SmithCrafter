using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewsManager : MonoBehaviour {

  // public List<GameObject> Views = new List<GameObject>();
   public GameObject[] Views;
   public TouchAction Touch_Action;
   public int CurrentView;
   public float CameraMoveSpeed;
   public double Delay;
   public Camera camera;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

}

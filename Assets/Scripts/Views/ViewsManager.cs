using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Views;

public class ViewsManager : MonoBehaviour {

  // public List<GameObject> Views = new List<GameObject>();
   public View[] Views;
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

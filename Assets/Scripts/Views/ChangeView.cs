using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeView : MonoBehaviour {

    public ViewsManager Manager;

    private Camera camera;
    private float CameraMoveSpeed;
    private int NextMove = 0;
    private System.DateTime Time;
    private GameObject[] Views;

	// Use this for initialization
	void Start () {
        Views = Manager.Views;
	}
	
	// Update is called once per frame
	void Update () {
	}
    
}




       /// float height = 2f * camera.orthographicSize;
     //   float width = height * camera.aspect;
///
       // view.transform.localScale = new Vector3(width, height, 0);
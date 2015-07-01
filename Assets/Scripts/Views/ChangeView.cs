using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeView : MonoBehaviour {

    public Camera camera;
    public float CameraMoveSpeed;
    private int NextMove = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Change(GameObject[] Views, TouchAction.Direction Direction, ref int CurrrentViewID)
    {
        Debug.Log(Direction);
    }
}




       /// float height = 2f * camera.orthographicSize;
     //   float width = height * camera.aspect;
///
       // view.transform.localScale = new Vector3(width, height, 0);
using UnityEngine;
using System.Collections;

public class HideCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Canvas canvas = GetComponent<Canvas>();
        canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

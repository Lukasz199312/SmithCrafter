using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DATA : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = PlayerPrefs.GetString("Time");
	}
}

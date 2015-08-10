using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PDATA : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerData.Time != null & PlayerData.Time.Length > 0)
        {
            DateTime time = new DateTime();
            time = DateTime.Parse(PlayerPrefs.GetString("Time"));

            TimeSpan diff = new TimeSpan();

            diff = DateTime.Now - time;

            text.text = diff.ToString();
        }
	}

}

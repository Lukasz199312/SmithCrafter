using UnityEngine;
using System.Collections;
using System;

public class LoadPlayerData : MonoBehaviour {
   
	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void CreateVariable()
    {
        if (PlayerPrefs.HasKey("Time") == false)
        {
            PlayerPrefs.SetString("Time", DateTime.Now.ToString());
            PlayerPrefs.SetInt("CharacterCount", 0);

            PlayerPrefs.SetInt("Gold", 0);
            PlayerPrefs.SetInt("IronOre", 0);
            PlayerPrefs.SetInt("SilverOre", 0);
            PlayerPrefs.SetInt("GoldOre", 0);
            PlayerPrefs.SetInt("Diamond", 0);
        }

    }
}

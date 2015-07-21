using UnityEngine;
using System.Collections;
using System;

public class IO_PlayerData : MonoBehaviour
{

	// Use this for initialization
	void Awake () {
        Load();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void Load()
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
        else
        {
            PlayerData.Time = PlayerPrefs.GetString("Time");
            PlayerData.CharacterCount = PlayerPrefs.GetInt("CharacterCount");
            PlayerData.Gold = PlayerPrefs.GetInt("Gold");
            PlayerData.IronOre = PlayerPrefs.GetInt("IronOre");
            PlayerData.SilverOre = PlayerPrefs.GetInt("SilverOre");
            PlayerData.GoldOre = PlayerPrefs.GetInt("GoldOre");
            PlayerData.Diamond = PlayerPrefs.GetInt("Diamond");
        }

    }

    public void Save()
    {
        PlayerPrefs.Save();
    }

    void OnApplicationQuit()
    {
        Save();
    }
}

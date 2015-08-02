using UnityEngine;
using Assets.Scripts.Views;
using System.Collections;
using System;

public class IO_PlayerData : MonoBehaviour
{

    public int NumberWorkstation;
    public ViewsManager _ViewManager;

	// Use this for initialization
	void Awake () {
        Load();
	}

    void Start()
    {

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
            InitializeWorkstation2();
        }

            PlayerData.Time = PlayerPrefs.GetString("Time");
            PlayerData.CharacterCount = PlayerPrefs.GetInt("CharacterCount");
            PlayerData.Gold = PlayerPrefs.GetInt("Gold");
            PlayerData.IronOre = PlayerPrefs.GetInt("IronOre");
            PlayerData.SilverOre = PlayerPrefs.GetInt("SilverOre");
            PlayerData.GoldOre = PlayerPrefs.GetInt("GoldOre");
            PlayerData.Diamond = PlayerPrefs.GetInt("Diamond");
            LoadWorkStaion();

  
    }

    public void Save()
    {
        PlayerPrefs.SetString("Time", DateTime.Now.ToString());
        PlayerPrefs.SetInt("CharacterCount", PlayerData.CharacterCount);

        PlayerPrefs.SetInt("Gold", PlayerData.Gold);
        PlayerPrefs.SetInt("IronOre", PlayerData.IronOre);
        PlayerPrefs.SetInt("SilverOre", PlayerData.SilverOre);
        PlayerPrefs.SetInt("GoldOre", PlayerData.GoldOre);
        PlayerPrefs.SetInt("Diamond", PlayerData.Diamond);


        PlayerPrefs.Save();
    }

    private void InitializeWorkstation()
    {
        string NameString = "Workstation-";

        PlayerData.Workstation = new WorkStation[NumberWorkstation];

        for (int i = 0; i < NumberWorkstation; i++)
        {
            bool result = PlayerPrefs.HasKey(NameString + i);
            if (result)
            {
                PlayerData.Workstation[i] = new WorkStation();
                PlayerData.Workstation[i].mode = (WorkStation.Mode)PlayerPrefs.GetInt(NameString + i);
                PlayerData.Workstation[i].ID = i;
            }
            else
            {
                PlayerData.Workstation[i] = new WorkStation();
                PlayerPrefs.SetInt(NameString + i, 0);
                PlayerData.Workstation[i].mode = WorkStation.Mode.TO_SELL;
                PlayerData.Workstation[i].ID = i;
            }
        }
    }

    private void InitializeWorkstation2()
    {
        string NameString = "Workstation-";

        foreach (View view in _ViewManager.Views)
        {
            foreach (WorkStation SingleWorkStation in view.WorkStations)
            {
                PlayerPrefs.SetInt(NameString + SingleWorkStation.ID, (int)SingleWorkStation.mode);
            }
        }
    }

    private void LoadWorkStaion()
    {
        PlayerData.Workstation = new WorkStation[NumberWorkstation];
        string NameString = "Workstation-";
        int i = 0;
        foreach (View view in _ViewManager.Views)
        {
            foreach (WorkStation SingleWorkStation in view.WorkStations)
            {

                SingleWorkStation.mode = (WorkStation.Mode)PlayerPrefs.GetInt(NameString + SingleWorkStation.ID);
                PlayerData.Workstation[SingleWorkStation.ID] = SingleWorkStation;
            }
        }
    }

    void OnApplicationQuit()
    {
        Save();
    }
}

using UnityEngine;
using System.Collections;
using System;

public class WorkStation : MonoBehaviour {

    public enum Mode:int
    {
        ACTIVE = 2,
        BUSY = 1,
        TO_SELL = 0,
        AUTO
    };

    public int Price;
    public Mode mode = new Mode();
    public int ID;
    public int Level;
    public float HitPoints;
    public float Speed;
    public StuffMenu Inventory;

    public Item CraftingItem;

    private DateTime Time;
    private const int MaxLevel = 3;
    private StationStatistic Statistic;
    private float ActualCraftingPoints;

    private bool PAUSE = false;
    private DateTime PauseTime = new DateTime();

	// Use this for initialization
	void Start () {

        Time = DateTime.Now;

        Statistic = new StationStatistic();

        Statistic.Level = this.Level;
        Statistic.HitPoints = this.HitPoints;
        Statistic.Speed = this.Speed;

       // TimeSpan timespan = DateTime.Now - DateTime.Parse(PlayerData.Time);
        if (mode == Mode.TO_SELL) return;
        DateTime time = new DateTime();
        time = DateTime.Parse(PlayerData.Time);

        TimeSpan timespan = DateTime.Now - time;

        int Frequency = (int)(timespan.TotalSeconds / Statistic.Speed);


        int Hits = (int)(timespan.TotalSeconds / Statistic.Speed);

        int craftResult = (int) (Hits * HitPoints ) / CraftingItem.Information.RequireHitPoints;
        if (craftResult > 0)
        {
            for (int i = 0; i < craftResult; i++)
            {
                Inventory.AddElement(CraftingItem);
                ActualCraftingPoints = ActualCraftingPoints + (Hits * HitPoints % CraftingItem.Information.RequireHitPoints);
            }
        }
        else
        {
            ActualCraftingPoints = ActualCraftingPoints + (Hits * HitPoints % CraftingItem.Information.RequireHitPoints);
        }

       // Debug.Log("Time span " + timespan.TotalSeconds);
       // Debug.Log("Frequency:" + Frequency);

        PlayerData.Gold = PlayerData.Gold + (25 * Frequency);
	}
	
	// Update is called once per frame
	void Update () {
        if (mode == Mode.TO_SELL) return;

        if (PAUSE == true)
        {
            PAUSE = false;


            TimeSpan timespan = DateTime.Now - PauseTime;

            int Frequency = (int)(timespan.TotalSeconds / Statistic.Speed);

            PlayerData.Gold = PlayerData.Gold + (25 * Frequency);
        }

        if (Time.AddSeconds(Statistic.Speed) < DateTime.Now)
        {
            ActualCraftingPoints = ActualCraftingPoints + 25;
            if (ActualCraftingPoints >= CraftingItem.Information.RequireHitPoints)
            {
                Inventory.AddElement(CraftingItem);
                ActualCraftingPoints = 0;
            }

           // PlayerData.Gold = PlayerData.Gold + 25;
            //PlayerData.UpdateResources();

            Time = DateTime.Now;
        }
	}

    


    void OnApplicationPause()
    {
        if (PAUSE == false)
        {
           // PAUSE = true;
           // PauseTime = DateTime.Now;

        }

    }

}

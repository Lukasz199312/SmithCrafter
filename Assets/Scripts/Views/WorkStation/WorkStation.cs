using UnityEngine;
using System.Collections;
using System;

public class WorkStation : MonoBehaviour
{

    public enum Mode : int
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
    public Inventory Inventory;
    public StuffMenu stuffMenu;

    public Item CraftingItem;

    private DateTime Time;
    private const int MaxLevel = 3;
    private StationStatistic Statistic;
    private float ActualCraftingPoints;

    private bool PAUSE = false;
    private DateTime PauseTime = new DateTime();

    public BoxCollider2D _boxCollider2D{ get; set; }
    public SpriteRenderer _SpriteRender { get; set; }


    private const int PartTime = 10;
  
    void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _SpriteRender = GetComponent<SpriteRenderer>();


        Statistic = new StationStatistic(HitPoints, Speed, Level, ActualCraftingPoints);
    }

    // Use this for initialization
    void Start()
    {
        Statistic = new StationStatistic(HitPoints, Speed, Level, 0);
     
        Time = DateTime.Now;

        // TimeSpan timespan = DateTime.Now - DateTime.Parse(PlayerData.Time);
        if (mode == Mode.TO_SELL) return;
        DateTime time = new DateTime();
        time = DateTime.Parse(PlayerData.Time);

        TimeSpan timespan = DateTime.Now - time;

        int Frequency = (int)(timespan.TotalSeconds / Statistic.Speed);


        int Hits = (int)(timespan.TotalSeconds / Statistic.Speed);

        int craftResult = (int)(Hits * HitPoints) / CraftingItem.Information.RequireHitPoints;
        if (craftResult > 0)
        {

            CraftingItem.Information.Number = CraftingItem.Information.Number + craftResult;
            stuffMenu.AddElement(CraftingItem);


            ActualCraftingPoints = ActualCraftingPoints + (Hits * HitPoints % CraftingItem.Information.RequireHitPoints);
           

            CraftingItem.Information.Number = 1;
        }
        else
        {
            ActualCraftingPoints = ActualCraftingPoints + (Hits * HitPoints % CraftingItem.Information.RequireHitPoints);

        }

        // Debug.Log("Time span " + timespan.TotalSeconds);
        // Debug.Log("Frequency:" + Frequency);

        //PlayerData.Gold = PlayerData.Gold + (25 * Frequency);
    }

    // Update is called once per frame
    void Update()
    {

        if (mode == Mode.TO_SELL) return;

        if (PAUSE == true)
        {
            PAUSE = false;

            TimeSpan timespan = DateTime.Now - PauseTime;

            int Frequency = (int)(timespan.TotalSeconds / Statistic.Speed);


            int Hits = (int)(timespan.TotalSeconds / Statistic.Speed);

            int craftResult = (int)(Hits * HitPoints) / CraftingItem.Information.RequireHitPoints;
            if (craftResult > 0)
            {
                for (int i = 0; i < craftResult; i++)
                {
                    stuffMenu.AddElement(CraftingItem);
                }

                ActualCraftingPoints = ActualCraftingPoints + (Hits * HitPoints % CraftingItem.Information.RequireHitPoints);
                Statistic.setActualHitPoints(ActualCraftingPoints);
            }
            else
            {
                ActualCraftingPoints = ActualCraftingPoints + (Hits * HitPoints % CraftingItem.Information.RequireHitPoints);
                Statistic.setActualHitPoints(ActualCraftingPoints);
            }
        }

        if (Time.AddSeconds(Statistic.Speed / PartTime) < DateTime.Now)
        {
            ActualCraftingPoints = ActualCraftingPoints + (HitPoints / PartTime);
            Statistic.setActualHitPoints(ActualCraftingPoints);

            if (ActualCraftingPoints >= CraftingItem.Information.RequireHitPoints)
            {
                stuffMenu.AddElement(CraftingItem);


                ActualCraftingPoints = 0;
            }

            // PlayerData.Gold = PlayerData.Gold + 25;
            //PlayerData.UpdateResources();

            Time = DateTime.Now;
        }
    }


    public StationStatistic getStatistic()
    {
        return Statistic;
    }



    void OnApplicationPause()
    {
        if (PAUSE == false)
        {
            PAUSE = true;
            PauseTime = DateTime.Now;

        }

    }

}
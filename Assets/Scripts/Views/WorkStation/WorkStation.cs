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

    private DateTime Time;
    private const int MaxLevel = 3;
    private StationStatistic Statistic;

	// Use this for initialization
	void Start () {
        Time = DateTime.Now;

        Statistic = new StationStatistic();

        Statistic.Level = this.Level;
        Statistic.HitPoints = this.HitPoints;
        Statistic.Speed = this.Speed;

        TimeSpan timespan = DateTime.Now - DateTime.Parse(PlayerData.Time);

        int Frequency = (int)(timespan.TotalSeconds / Statistic.Speed);

        Debug.Log("Time span " + timespan.TotalSeconds);
        Debug.Log("Frequency:" + Frequency);

        PlayerData.Gold = PlayerData.Gold + (25 * Frequency);
	}
	
	// Update is called once per frame
	void Update () {
        if (mode == Mode.TO_SELL) return;

        if (Time.AddSeconds(Statistic.Speed) < DateTime.Now)
        {
            PlayerData.Gold = PlayerData.Gold + 25;
            PlayerData.UpdateResources();

            Time = DateTime.Now;
        }
	}






}

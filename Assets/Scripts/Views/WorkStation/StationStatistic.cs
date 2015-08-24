using UnityEngine;
using System.Collections;

public class StationStatistic : MonoBehaviour{

    public float HitPoints { get; private set; }
    public float Speed { get; private set; }
    public int Level { get; private set; }
    public float ActualHitPoints { get; private set; }

    public StationStatistic(float HitPoints, float Speed, int Level, float ActualHitPoints)
    {
        this.HitPoints = HitPoints;
        this.Speed = Speed;
        this.Level = Level;
        this.ActualHitPoints = ActualHitPoints;
    }

    public void setActualHitPoints(float ActialHitPoints)
    {
        this.ActualHitPoints = ActualHitPoints;
    }
}

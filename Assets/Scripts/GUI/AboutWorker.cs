using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AboutWorker : MonoBehaviour {

    public Text Speed;
    public Text HitPower;
    public Text Progress;
    public Text ProgressGoal;
    public Text PercentProgress;
    public RectTransform ProgressBar;
    public RawImage Image;

    private StationStatistic Statistic;
    private Item item;
    private float StartPosition;

	// Use this for initialization
	void Start () {
        StartPosition = ProgressBar.anchoredPosition.x;
        gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
        Progress.text = Statistic.ActualHitPoints.ToString();
        CalculateProgressBar();
        
	}

    public void ToggleOn(WorkStation Station , Item item)
    {
        gameObject.SetActive(true);

        Statistic = Station.getStatistic();
        Speed.text = Statistic.Speed.ToString();
        HitPower.text = Statistic.HitPoints.ToString();
        ProgressGoal.text = item.Information.RequireHitPoints.ToString();
        this.item = item;

        Image.texture = item.image.sprite.texture;
    }

    private void CalculateProgressBar()
    {
        float PercentGoal = Statistic.ActualHitPoints / item.Information.RequireHitPoints;
        Debug.Log(PercentGoal);

        ProgressBar.anchoredPosition = new Vector3(-1 * (100 + StartPosition - (PercentGoal * 100)),
                                   ProgressBar.anchoredPosition.y);

        ProgressBar.localScale = new Vector3(0 + PercentGoal ,1,1);
        PercentProgress.text = ( (int)(PercentGoal * 100) ).ToString() + " %";


    }
}

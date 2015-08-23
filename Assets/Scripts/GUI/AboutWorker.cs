using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AboutWorker : MonoBehaviour {

    public Text Speed;
    public Text HitPower;
    public Text Progress;
    public Text PercentProgress;

    private StationStatistic Statistic;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ToggleOn(WorkStation Station)
    {
        gameObject.SetActive(true);

        Statistic = Station.getStatistic();

    }
}

using UnityEngine;
using System.Collections;

public class WorkStation : MonoBehaviour {

    public enum Mode
    {
        ACTIVE,
        BUSY,
        TO_SELL
    };

    public int Price;
    public Mode mode = new Mode();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

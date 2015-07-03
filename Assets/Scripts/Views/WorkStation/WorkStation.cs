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
       // Debug.Log(transform.parent.gameObject.transform.parent.name);
	}
	
	// Update is called once per frame
	void Update () {
	}
}

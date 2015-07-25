using UnityEngine;
using System.Collections;

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

    public int test;

    private const int MaxLevel = 3;
    private int Level;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public bool AddLevel()
    {
        if (Level + 1 <= MaxLevel)
        {
            Level = Level + 1;
            return true;
        }
        else return false;
    }
}

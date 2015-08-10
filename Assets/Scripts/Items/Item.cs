using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public ItemInformation Information;
    private int SlotID;

	// Use this for initialization
	void Start () {
       // Information = GetComponent<ItemInformation>();
        if (Information == null) Information = new ItemInformation();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getSlotID()
    {
        return SlotID;
    }

    public void setSlotID(int id)
    {
        SlotID = id;
    }
}

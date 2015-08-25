using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Item : MonoBehaviour, ICloneable {

    public ItemInformation Information;
    private int SlotID;
    public Image image {  get; private set; }

	// Use this for initialization
	void Start () {
       // Information = GetComponent<ItemInformation>();
        if (Information == null) Information = new ItemInformation();
        image = GetComponent<Image>();
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

    public object Clone()
    {
        Item newItem = (Item) this.MemberwiseClone();
        newItem.Information = (ItemInformation) this.Information.Clone();

        return newItem;

    }

    public static void CopyReference(object A, object B)
    {
        A = B;
    }
}

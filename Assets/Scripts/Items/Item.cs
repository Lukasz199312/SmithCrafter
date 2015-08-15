using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Item : MonoBehaviour, ICloneable {

    public ItemInformation Information;

    private Image ItemImage;
    public int SlotID;

	// Use this for initialization
	void Start () {
       // Information = GetComponent<ItemInformation>();
        if (Information == null) Information = new ItemInformation();

        ItemImage = gameObject.GetComponent<Image>();
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

    public Sprite getSprite()
    {
        return this.ItemImage.sprite;
    }

    public object Clone()
    {
        Item newItem = (Item)this.MemberwiseClone();
        newItem.Information = (ItemInformation)Information.Clone();

        return newItem;
    }

    public void SetReference(Item item)
    {
        Information = item.Information;
        ItemImage = item.ItemImage;
        SlotID = item.SlotID;
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ItemInformation : MonoBehaviour, ICloneable
{
    public string ItemName;
    public int MinDMG;
    public int MaxDMG;
    public int SellPrice;
    public int Number;

    //Craft Information
    public int RequireHitPoints;

    private int ITEM_ID;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetID(int ID)
    {
        ITEM_ID = ID;
    }

    public int getID()
    {
        return ITEM_ID;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}

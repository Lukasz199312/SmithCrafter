using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopItem : MonoBehaviour
{
    protected Button BuyButton;
    protected Image ItemGUi;
    protected bool Unlocked = false;

    public Color ColorBoughtedPanel;

    void Awake()
    {
        BuyButton = GetComponentInChildren<Button>();
        ItemGUi = GetComponent<Image>();
    }


    public bool isUnlocked()
    {
        return Unlocked;
    }
}   

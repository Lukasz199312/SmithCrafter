using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponShopItem : ShopItem, IActionShopItem
{

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Buy()
    {
        ItemGUi.color = ColorBoughtedPanel;
        BuyButton.interactable = false;

        Unlocked = true;
    }

}

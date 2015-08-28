using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponShopItem : ShopItem, IActionShopItem
{

	// Use this for initialization
	void Start () {
        if (ItemObject.GetComponent<Item>().isUnlocked == true) Unlock();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Buy(int Price)
    {
        if (PlayerData.Gold >= Price)
        {
            PlayerData.Gold = PlayerData.Gold - Price;
            PlayerData.UpdateResources();
            Unlock();
        }
        else Debug.Log("Masz za malo kasy dorob okno leniu");
        // w przeciwnym wypadku wyswietlic ma sie okno informujace o braku kasy
    }

}

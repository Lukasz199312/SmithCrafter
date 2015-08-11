using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogBox : MonoBehaviour {

    public Button Sell;
    public Button Sell_ALL;
    public GameObject SelectedItem;
    public StuffMenu stuffMenu;
    public RawImage IconImage;
    public Text NameItem;
    public Text DMG;
    public Text Pieces;
    public Text Price;
    public Item item;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Sell_Stuff()
    {
        Debug.Log(stuffMenu.transform.GetChild(0).childCount);
        this.gameObject.SetActive(false);
        SelectedItem.transform.parent = null;
        Destroy(SelectedItem);
        stuffMenu.Sort();
        PlayerData.Gold = PlayerData.Gold  + (item.Information.SellPrice * item.Information.Number);
        PlayerData.UpdateResources();
        Debug.Log(PlayerData.Gold);
        PlayerData.RemoveSlot(item.getSlotID());
    }

    public void SetDMG(string MIN, string Max)
    {
        DMG.text = "DMG: " + " " + MIN + " ~ " + Max;
    }
}

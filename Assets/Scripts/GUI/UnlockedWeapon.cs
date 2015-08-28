using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnlockedWeapon : MonoBehaviour {

    public RawImage ItemImage;
    public Text Name;
    public Text SellPrice;
    public Text Dmg;

    public Text RequireIronOre;
    public Text RequireSilverOre;
    public Text RequireDiamondOre;

    private Item item;

	// Use this for initialization
	void Start () {
        if (item == null) return;
        Name.text = item.Information.ItemName;
        SellPrice.text = "Sell Price: " + item.Information.SellPrice;
        Dmg.text = "DMG: " + item.Information.MaxDMG;
        ItemImage.texture = item.image.sprite.texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setItem(Item item)
    {
        this.item = item;
    }

    public Item getItem()
    {
        return item;
    }
}

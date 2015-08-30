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

    public Button StartCraftButton;

    private Item item;
    public Image MainImage;

	// Use this for initialization
	void Start () {
        if (item == null) return;
        Name.text = item.Information.ItemName;
        SellPrice.text = "Sell Price: " + item.Information.SellPrice;
        Dmg.text = "DMG: " + item.Information.MaxDMG;
        ItemImage.texture = item.image.sprite.texture;

        Debug.Log("TEST COLOOOOOOOOR" + gameObject.GetComponent<Image>());

        MainImage = gameObject.GetComponent<Image>();
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

    public Image GetMainImage()
    {
        return MainImage;
    }

    public void ChangeCraftItem(WorkStation Station)
    {
        Station.CraftingItem = item;
        Debug.Log("item name:" + item.name);
    }

    public void UpdateMainImage()
    {
        MainImage = gameObject.GetComponent<Image>();
    }

    public void SetAsActive(Color color)
    {
        MainImage.color = color;
        StartCraftButton.interactable = false;
    }

    public void SetAsDeselect(Color color)
    {
        MainImage.color = color;
        StartCraftButton.interactable = true;
    }
}

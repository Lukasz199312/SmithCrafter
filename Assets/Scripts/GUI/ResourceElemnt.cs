using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceElemnt : MonoBehaviour{

    public enum Element
    {
        GOLD,
        IRON_ORE,
        SILVER_ORE,
        GOLD_ORE,
        DIAMOND
    };

    public Element ElementType;

    private Text ResourceText;
    private string ResourceName;
    private object Value;

	// Use this for initialization
	void Start () {
        ResourceText = GetComponent<Text>();
        ResourceName = ResourceText.text;

        UpdateResource();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void UpdateResource()
    {
        switch (ElementType)
        {
            case Element.GOLD:
                Value = PlayerData.Gold;
                ResourceText.text = ResourceName + Value.ToString();
                break;

            case Element.IRON_ORE:
                Value = PlayerData.IronOre;
                ResourceText.text = ResourceName + Value.ToString();
                break;

            case Element.SILVER_ORE:
                Value = PlayerData.SilverOre;
                ResourceText.text = ResourceName + Value.ToString();
                break;

            case Element.GOLD_ORE:
                Value = PlayerData.GoldOre;
                ResourceText.text = ResourceName + Value.ToString();
                break;

            case Element.DIAMOND:
                Value = PlayerData.Diamond;
                ResourceText.text = ResourceName + Value.ToString();
                break;
        }
        
    }
}

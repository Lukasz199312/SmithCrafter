using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Shop : MonoBehaviour {

    public List<GameObject> StuffList;

    private List<IActionShopItem> Stuffs = new List<IActionShopItem>();

	// Use this for initialization
	void Awake () {
        IEnumerator enumerator = StuffList.GetEnumerator();

        while(enumerator.MoveNext())
        {
            Stuffs.Add( ((GameObject)enumerator.Current).GetComponent<IActionShopItem>() );
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    public List<IActionShopItem> getStuffList()
    {
        return Stuffs;
    }

    public string ReturnStringStuffList()
    {
        IEnumerator enumerator = Stuffs.GetEnumerator();
        string Items = "";
        
        while (enumerator.MoveNext())
        {
            Items = Items + "0";
        }

        return Items;
    }

    public void setStringStuffList(string Items)
    {
        IEnumerator enumerator = Stuffs.GetEnumerator();

        int Index = 0;
        while (enumerator.MoveNext())
        {
            int Value = Int32.Parse(Items.Substring(Index,1));
            Debug.Log(Value);
            if (Value == 1)
            {
                ((IActionShopItem)enumerator.Current).Buy();
                Debug.Log("Kupilem To co chcialem");
            }
            Index++;
        }
    }
}

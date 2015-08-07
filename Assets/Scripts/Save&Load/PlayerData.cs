using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour {

    public static string Time;
    public static int CharacterCount;
    public static int Gold;
    public static int IronOre;
    public static int SilverOre;
    public static int GoldOre;
    public static int Diamond;
    public static WorkStation[] Workstation;

    private static int InventoryHeadID;
    private static ResourcesManager Resources;
    private static WeaponCollection WeaponList; // to delte

    private static ArrayList Weapons = new ArrayList();

	// Use this for initialization
	void Start () {
	}


	
	// Update is called once per frame
	void Update () {
	}

    public static void setResourcesManager(ResourcesManager RM)
    {
        Resources = RM;
    }

    public static void setWeaponList(WeaponCollection weaponCollection)
    {
        WeaponList = weaponCollection;
    }

    public static void UpdateResources(){
        Resources.UpdateAll();
    }

    public static void AddWeapon(Item item)
    {

        foreach (Item weapon in Weapons)
        {
            if (weapon.Information.getID() == item.Information.getID())
            {
                weapon.Information.Number++;
                Debug.Log("Zwieszkono ilosc itemu");
                return;
            }
        }
        InventoryHeadID++;
        item.Information.Number++;
        Weapons.Add(item);
        Debug.Log("dodano nowy slot");
    }

    public static void IncreaseInventoryHead()
    {
        InventoryHeadID++;
    }

    public static void DecreaseInventoryHead()
    {
        InventoryHeadID--;
    }

    public static int GetInventoryHead()
    {
        return InventoryHeadID;
    }

    public static ArrayList getWeaponsList()
    {
        return Weapons;
    }
}


/*
WorkStation int

*/
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

    public static bool AddWeapon(Item item) // zwraca true jestli tworzy nowy slot
    {

        foreach (Item weapon in Weapons)
        {
            if (weapon.Information.getID() == item.Information.getID())
            {

                weapon.setSlotID(InventoryHeadID);
                weapon.Information.Number++;
                return false;
            }
        }
        InventoryHeadID++;
        item.Information.Number++;
        item.setSlotID(InventoryHeadID);
        Weapons.Add(item);
        Debug.Log("dodano nowy slot");
        return true;

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

    public static void setInventoryHeadID(int ID)
    {
        InventoryHeadID = ID;
    }

    public static ArrayList getWeaponsList()
    {
        return Weapons;
    }

    public static void RemoveSlot(int id)
    {
        Debug.Log("PRZED: " + Weapons.ToArray().Length);
        Debug.Log("INDEX TO DELETE: " + (id -1).ToString() );
        Weapons.RemoveAt(id-1);
        Debug.Log("PO: " + Weapons.ToArray().Length);
        DecreaseInventoryHead();
    }

    public static void SortSlots()
    {
        int id = 1;

        foreach (Item item in Weapons)
        {
            Debug.Log(" Before SORT ITEM ID:" + id);
        }

        foreach(Item item in Weapons)
        {
            item.setSlotID(id);
            Debug.Log(" After SORT ITEM ID:" + id);
            id++;
        }
    }
}


/*
WorkStation int

*/
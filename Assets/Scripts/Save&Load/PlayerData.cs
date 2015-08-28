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
    public static List<Item> UnlockedWeapons = new List<Item>();

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
                Debug.Log("Zwieszkono ilosc itemu");
                return false;
            }
        }

        Item newItem = (Item)item.Clone();

        InventoryHeadID++;
        newItem.Information.Number++;
        newItem.setSlotID(InventoryHeadID);
        Weapons.Add(newItem);
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
        Weapons.RemoveAt(id-1);
        Debug.Log("PO: " + Weapons.ToArray().Length);
        DecreaseInventoryHead();
    }

    public static void SortSlots()
    {
        int id = 1;
        foreach(Item item in Weapons)
        {
            item.setSlotID(id);
            id++;
        }
    }

    public static bool isSlotExist(Item item)
    {
        foreach (Item weapon in Weapons)
        {
            if (weapon.Information.getID() == item.Information.getID())
            {
                weapon.setSlotID(InventoryHeadID);
                weapon.Information.Number++;
                Debug.Log("Zwieszkono ilosc itemu");
                return true;
            }
        }

        return false;
    }

   public static void addUnlockedWeapon(Item WeaponObject)
   {
       UnlockedWeapons.Add(WeaponObject);
   }

   public static IEnumerator<Item> getUnlockedWeaponEnumerator()
   {
       return UnlockedWeapons.GetEnumerator();
   }

   public static List<Item> getUnlockedWeaponsList()
   {
       return UnlockedWeapons;
   }
}


/*
WorkStation int

*/
using UnityEngine;
using Assets.Scripts.Views;
using System.Collections;
using System;

public class IO_PlayerData : MonoBehaviour
{

    public int NumberWorkstation;
    public ViewsManager _ViewManager;
    public WeaponCollection WeaponList;
    public Inventory inventory;
    public Shop shop;

    // Use this for initialization
    void Awake()
    {
      //  PlayerPrefs.DeleteAll();
        Load();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey("Time") == false)
        {

            PlayerPrefs.SetString("Time", DateTime.Now.ToString() );
            PlayerPrefs.SetInt("CharacterCount", 0);
            PlayerPrefs.SetInt("InventoryHeadID", 0);

            PlayerPrefs.SetInt("Gold", 0);
            PlayerPrefs.SetInt("IronOre", 0);
            PlayerPrefs.SetInt("SilverOre", 0);
            PlayerPrefs.SetInt("GoldOre", 0);
            PlayerPrefs.SetInt("Diamond", 0);
            InitializeWorkstation2();
            InitializeShop();
            IntializeWeapon();
        }

        PlayerData.Time = PlayerPrefs.GetString("Time");
        PlayerData.CharacterCount = PlayerPrefs.GetInt("CharacterCount");
        PlayerData.setInventoryHeadID(0);


        PlayerData.Gold = PlayerPrefs.GetInt("Gold");
        PlayerData.IronOre = PlayerPrefs.GetInt("IronOre");
        PlayerData.SilverOre = PlayerPrefs.GetInt("SilverOre");
        PlayerData.GoldOre = PlayerPrefs.GetInt("GoldOre");
        PlayerData.Diamond = PlayerPrefs.GetInt("Diamond");
        LoadWorkStaion();
        LoadInventory();
        LoadWeapon();
        shop.setStringStuffList(PlayerPrefs.GetString("Shop"));

    }

    public void Save()
    {

        PlayerPrefs.SetString("Time", DateTime.Now.ToString());
        PlayerPrefs.SetInt("CharacterCount", PlayerData.CharacterCount);

        PlayerPrefs.SetInt("Gold", PlayerData.Gold);
        Debug.Log("SAVE GOLD ****** " + PlayerData.Gold + " *******");
        PlayerPrefs.SetInt("IronOre", PlayerData.IronOre);
        PlayerPrefs.SetInt("SilverOre", PlayerData.SilverOre);
        PlayerPrefs.SetInt("GoldOre", PlayerData.GoldOre);
        PlayerPrefs.SetInt("Diamond", PlayerData.Diamond);

        SaveInventory();
       // SaveShopInformation();
        SaveUnlockedWeapons();

        PlayerPrefs.SetInt("InventoryHeadID", inventory.InventoryHeadID );
        PlayerPrefs.Save();
    }

    private void InitializeWorkstation2()
    {
        string NameString = "Workstation-";
        foreach (View view in _ViewManager.Views)
        {
            foreach (WorkStation SingleWorkStation in view.WorkStations)
            {
                PlayerPrefs.SetInt(NameString + SingleWorkStation.ID, (int)SingleWorkStation.mode);
            }
        }
    }

    private void InitializeShop()
    {
        
        Debug.Log(shop.ReturnStringStuffList());

        PlayerPrefs.SetString("Shop", "000");
    }

    private void IntializeWeapon()
    {
        String  ByteWeaponsList = "";
        foreach(Item SingleWeapon in WeaponList.WeaponsList)
        {
            if (SingleWeapon.isUnlocked == true) ByteWeaponsList = ByteWeaponsList + "1";
            else ByteWeaponsList = ByteWeaponsList + "0";
        }

        PlayerPrefs.SetString("WeaponList", ByteWeaponsList);
    }

    private void LoadWorkStaion()
    {
        PlayerData.Workstation = new WorkStation[NumberWorkstation];
        string NameString = "Workstation-";
        int i = 0;
        foreach (View view in _ViewManager.Views)
        {
            foreach (WorkStation SingleWorkStation in view.WorkStations)
            {

                SingleWorkStation.mode = (WorkStation.Mode)PlayerPrefs.GetInt(NameString + SingleWorkStation.ID);
                PlayerData.Workstation[SingleWorkStation.ID] = SingleWorkStation;
            }
        }
    }


    private void SaveInventory()
    {

        for (int i = 1; i <= inventory.InventoryHeadID; i++)
        {
            PlayerPrefs.DeleteKey("SLOT_" + i);

        }


        int ID = 1;
        String ItemID = "";

        foreach (Item SingleItem in inventory.WeaponsList)
        {
            if (SingleItem.Information.getID() < 10) ItemID = "00";
            else if (SingleItem.Information.getID() < 100) ItemID = "0";

            String strID = IntToString(SingleItem.Information.getID());
            String strNumber = SingleItem.Information.Number.ToString();

            Debug.Log(strID);
            Debug.Log(strNumber);

            PlayerPrefs.SetString("SLOT_" + ID, strID + strNumber);
            ID++;
        }
    }


    private void SaveShopInformation()
    {
        //PlayerPrefs.SetString("Shop", shop.ReturnStringStuffList());
    }

    private void LoadInventory()
    {
        int ID = PlayerPrefs.GetInt("InventoryHeadID");
        for (int i = 1; i <= ID; i++)
        {
            String strItem = PlayerPrefs.GetString("SLOT_" + i);

            String strID = strItem.Substring(0, 3);
            Debug.Log(strID);

            String strNumber = strItem.Substring(3);
            Debug.Log(strNumber);

            Item Weapon = (Item) WeaponList.WeaponsList[Convert.ToInt32(strID)].Clone();

            Weapon.Information.SetID(Convert.ToInt32(strID));
            Weapon.Information.Number = Convert.ToInt32(strNumber);
            Weapon.setSlotID(i);

            inventory.Add(ref Weapon);
            Weapon.Information.Number--;
            
        }
    }

   private void LoadWeapon()
   {
       String Weapons = PlayerPrefs.GetString("WeaponList");

       IEnumerator enumerator = WeaponList.WeaponsList.GetEnumerator();

       int id = 0;
       while(enumerator.MoveNext())
       {
           Item WeaponItem = (Item)enumerator.Current;
           object obj = Weapons.ToCharArray().GetValue(id);
           int Value = Convert.ToInt32( obj.ToString() );

           if (Value == 1)
           {
               WeaponItem.isUnlocked = true;
               PlayerData.addUnlockedWeapon(WeaponItem);
           }

           id++;
       }

   }

    private void SaveUnlockedWeapons()
   {
       IEnumerator enumerator = WeaponList.WeaponsList.GetEnumerator();
       String str = "";
       while (enumerator.MoveNext())
       {
           if (((Item)enumerator.Current).isUnlocked == true) str = str + "1";
           else str = str + "0";
       }

       PlayerPrefs.SetString("WeaponList", str);
   }


    private String IntToString(int Number)
    {
        String strNumber = "";

        if (Number < 10) strNumber = "00";
        else if (Number < 100) strNumber = "0";
        strNumber = strNumber + Number.ToString();

        return strNumber;
    }

    void OnApplicationPause()
    {
         //Save();
    }

    void OnApplicationQuit()
    {
        Save();
    }
  
}

// SWORD
// [NAZWA_MIECZA] [
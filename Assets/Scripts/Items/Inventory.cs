using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

    public ArrayList WeaponsList = new ArrayList();
    public int InventoryHeadID = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public bool Add(ref Item item)
    {

        IEnumerator enumerator = WeaponsList.GetEnumerator();

        while(enumerator.MoveNext())
        {
            Item weapon = (Item)enumerator.Current;
            if (weapon.Information.getID() == item.Information.getID())
            {
              //  weapon.setSlotID(InventoryHeadID);
                weapon.Information.Number = weapon.Information.Number + item.Information.Number;


               // Debug.Log("Zwieszkono ilosc itemu *********");
                return false;
            }
        }

        Debug.Log("Dodano NOWY  itemu *********");
        Item newItem = (Item)item.Clone();
        item = newItem;

        InventoryHeadID++;
        item.Information.Number++;
        item.setSlotID(InventoryHeadID);
        WeaponsList.Add(item);

        enumerator = WeaponsList.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if( object.ReferenceEquals(item, enumerator.Current) )
                Debug.Log("WYSTEPUJE KURWA JEBANA REFERENCJA POMIEDZY POIERDOLONYI OBIEKTAMI");
        }
        return true;
    }

    public void RemoveSlot(int id, Item item)
    {
        IEnumerator enumerator1 = WeaponsList.GetEnumerator();
        enumerator1.Reset();
        while (enumerator1.MoveNext())
        {
            object obj = enumerator1.Current;
            if (item.getSlotID() == ((Item)obj).getSlotID())
                if (object.ReferenceEquals(item, enumerator1.Current))
                {
                    Debug.Log("***Reference DELETE: REMOVE SLOT ID: " + ((Item)enumerator1.Current).getSlotID() );
                    WeaponsList.Remove(enumerator1.Current);

                    enumerator1 = WeaponsList.GetEnumerator();
                    InventoryHeadID--;
                    SortSlots();
                    return;
                }
         
        }

        Debug.Log("PRZED: " + WeaponsList.ToArray().Length);
        Debug.Log("Item ID: " + id);
       // WeaponsList.RemoveAt(id - 1);
        Debug.Log("PO: " + WeaponsList.ToArray().Length);
        InventoryHeadID--;
        SortSlots();


        enumerator1 = WeaponsList.GetEnumerator();
        while (enumerator1.MoveNext())
        {
            object obj = enumerator1.Current;
            Debug.Log("Reference DELETE: REMOVE SLOR OK ***************" + ( ( (Item) enumerator1.Current).getSlotID() ));
            if (item.getSlotID() == ((Item)obj).getSlotID())
                if (object.ReferenceEquals(item, obj)) Debug.Log("Reference DELETE: REMOVE SLOR OK ***************");
        }
    }

    public bool isSlotExist(Item item)
    {

        IEnumerator enumrator = WeaponsList.GetEnumerator();
        
        while(enumrator.MoveNext())
        {
            Item weapon = (Item)enumrator.Current;

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

    public void SortSlots()
    {
        int id = 1;
        IEnumerator enumerator = WeaponsList.GetEnumerator();

        while (enumerator.MoveNext())
        {
            ((Item) enumerator.Current).setSlotID(id);
            Debug.Log("ID SORT " + ((Item)enumerator.Current).getSlotID());
            //item.setSlotID(id);
            id++;
        }

         enumerator = WeaponsList.GetEnumerator();

        while (enumerator.MoveNext())
        {
            Debug.Log("ID SORT 2" + ((Item)enumerator.Current).getSlotID());
            //item.setSlotID(id);
 
        }
    }
}

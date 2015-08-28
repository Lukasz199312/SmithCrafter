using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StuffMenu : MonoBehaviour {

    public List<RectTransform> Stuffs;
    public RectTransform StuffBackground;
    public Vector2 CelSize;
    public GameObject DialogBox;
    public Canvas MainCanvas;
    public WeaponCollection WeaponsList;
    public Inventory inventory;

    private int MaxElementVertical;
    private int MaxElementHorizontal;

    private Vector2 ContentSize = new Vector2();
    private Vector2 Pointer = new Vector2(0,0);

    private DialogBox DialogBoxScript;

	// Use this for initialization
	void Start () 
    {
        if (MainCanvas.enabled == false) MainCanvas.enabled = true;
        CalculateMaxElementHorizontal();
        CalculateMaxElementVertical();
        DialogBox.SetActive(false);
        MainCanvas.enabled = false;

        DialogBoxScript = DialogBox.GetComponent<DialogBox>();
        AddToBackpack();



	}

    void Awake()
    {

    }
	// Update is called once per frame
	void Update () {
	}

    private void AddToBackpack()
    {

       Debug.Log("DATA LENGHT: " + WeaponsList.WeaponsList.Length);
        int Slot_ID = 0;

       IEnumerator enumerator = inventory.WeaponsList.GetEnumerator();
       while (enumerator.MoveNext())
       {
           Item item = (Item)enumerator.Current;



           IEnumerator enumerator1 = inventory.WeaponsList.GetEnumerator();
           while (enumerator1.MoveNext())
           {
               object obj = enumerator1.Current;

               if (object.ReferenceEquals(obj, item)) Debug.Log("****************");
           }


      // item = (Item)PlayerData.getWeaponsList().ToArray().GetValue(Slot_ID);
       Debug.Log("StuffMenu Number item: " +  item.Information.Number.ToString() );

       bool result = inventory.isSlotExist(item);

        if(result)
        {
            RectTransform stuffObject = Instantiate(WeaponsList.WeaponsList[item.Information.getID()]).GetComponent<RectTransform>();

            RectTransform Stuff = Instantiate(stuffObject);

            Stuff.GetComponent<Item>().Information = item.Information;

            Stuff.parent = StuffBackground;

            Stuff.GetComponent<Button>().onClick.AddListener(() => setDialogBox(DialogBox, Stuff.gameObject, ref item));


            Stuff.sizeDelta = CelSize;

            SetPosition(Stuff);
            Stuff = AnchorOpertion.SetAnchor(Stuff);

            Stuffs.Add(Stuff);
            CalculatePointer();
        } else
        {
            item.Information.Number++;
        }

        Slot_ID++;
       }
    }
    

    public void AddElement(Item item)
    {
       bool result =  inventory.Add(ref item);

        if (result)
        {

            IEnumerator enumerator = inventory.WeaponsList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (object.ReferenceEquals(item, enumerator.Current))
                    Debug.Log("KURWAAAAAAAAAAAAAAAAA****************");
            }

            RectTransform Stuff = Instantiate < RectTransform > (item.GetComponent<RectTransform>());

            Stuff.parent = StuffBackground;

            Stuff.GetComponent<Button>().onClick.AddListener(() => setDialogBox(DialogBox, Stuff.gameObject, ref item));


            Stuff.sizeDelta = CelSize;

            SetPosition(Stuff);
            Stuff = AnchorOpertion.SetAnchor(Stuff);

            Stuffs.Add(Stuff);
            CalculatePointer();
        }



    }


    private void SetPosition(RectTransform transfom)
    {
        float x = (StuffBackground.position.x - StuffBackground.rect.width / 2 + CelSize.x / 2) + (CelSize.x) * Pointer.x;
        float y = (StuffBackground.position.y + StuffBackground.rect.height / 2 - CelSize.y / 2) - (CelSize.y) * Pointer.y;
        transfom.position = new Vector3(x, y,transfom.position.z);
    }

    private void CalculatePointer()
    {
        if (Pointer.x < MaxElementHorizontal - 1)
        {
            Pointer.x = Pointer.x + 1;
        }
        else
        {
            Pointer.y = Pointer.y + 1;
            Pointer.x = 0;
        }
    }

    private void CalculateMaxElementHorizontal()
    {
        MaxElementHorizontal= (int) (StuffBackground.rect.width / CelSize.x);
    }

    private void CalculateMaxElementVertical() // height
    {
        MaxElementVertical = (int)(StuffBackground.rect.height / CelSize.y);
    }

    public void Sort()
    {
        Pointer = Vector2.zero;
        int Size = transform.GetChild(0).childCount;
        Debug.Log(Size);
        for (int i = 0; i <= Size - 1; i++)
        {
            RectTransform Stuff_item =  transform.GetChild(0).GetChild(i) as RectTransform;
            SetPosition(Stuff_item);
            Stuff_item = AnchorOpertion.SetAnchor(Stuff_item);
            CalculatePointer();
        }
    }

    public void setDialogBox(GameObject DialogBox, GameObject Stuff, ref Item item)
    {
        DialogBox.SetActive(true);
        DialogBoxScript.SelectedItem = Stuff;
        DialogBoxScript.stuffMenu = this;

        
     //   Debug.Log(Stuff.GetComponent<Image>().sprite.name);
        DialogBoxScript.IconImage.texture = Stuff.GetComponent<Image>().sprite.texture;

        DialogBoxScript.NameItem.text = "Name: " + item.Information.name;
        DialogBoxScript.SetDMG(item.Information.MinDMG.ToString(), item.Information.MaxDMG.ToString());
        DialogBoxScript.Pieces.text = "Pieces: " + item.Information.Number;
        DialogBoxScript.Price.text = "Price: " + item.Information.SellPrice;
        DialogBoxScript.item = item;

        IEnumerator enumerator1 = inventory.WeaponsList.GetEnumerator();
        enumerator1.Reset();
        while (enumerator1.MoveNext())
        {
             object obj = enumerator1.Current;
            
            if (object.ReferenceEquals(DialogBoxScript.item, obj)) Debug.Log("DIALOG BOX REFERENCE [2] ****************");
        }
       
    }

    public void Sell_ALL()
    {
        Pointer = Vector2.zero;
        int Size = transform.GetChild(0).childCount;
        Debug.Log(Size);
        for (int i = 0; i <= Size - 1; i++)
        {
            RectTransform Stuff_item = transform.GetChild(0).GetChild(i) as RectTransform;
            Destroy(Stuff_item.gameObject);
        }
    }

}

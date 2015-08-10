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

        for (int i = 1; i <= PlayerData.GetInventoryHead(); i++)
        {
            AddToInventory(i);
        }
	}

    void Awake()
    {

    }
	// Update is called once per frame
	void Update () {
	}

    public void AddToInventory(int i)
    {
        Debug.Log("DATA LENGHT: " + PlayerData.getWeaponsList().ToArray().Length);
        i = i - 1;
       Item item =  (Item)PlayerData.getWeaponsList().ToArray().GetValue(i);
       Debug.Log("StuffMenu Number item: " +  item.Information.Number.ToString() );

       RectTransform stuffObject = Instantiate(WeaponsList.WeaponsList[item.Information.getID()]).GetComponent<RectTransform>();

       RectTransform Stuff = Instantiate(stuffObject);
       Stuff.parent = StuffBackground;

       Stuff.GetComponent<Button>().onClick.AddListener(() => setDialogBox(DialogBox, Stuff.gameObject, item));


       Stuff.sizeDelta = CelSize;

       SetPosition(Stuff);
       Stuff = SetAnchor(Stuff);

       Stuffs.Add(Stuff);
       CalculatePointer();

    }

    public void AddElement(int id)
    {

        Item item = new Item();
        item.Information = new ItemInformation();
        item.Information.SetID(id);

        item = WeaponsList.WeaponsList[id];

        bool result = PlayerData.AddWeapon(item);

        if(result){
            RectTransform stuffObject = Instantiate(WeaponsList.WeaponsList[item.Information.getID()]).GetComponent<RectTransform>();

            RectTransform Stuff = Instantiate(stuffObject);
            Stuff.parent = StuffBackground;

            Stuff.sizeDelta = CelSize;

            SetPosition(Stuff);
            Stuff = SetAnchor(Stuff);

            Stuffs.Add(Stuff);
            CalculatePointer();
            Stuff.GetComponent<Button>().onClick.AddListener(() => setDialogBox(DialogBox, Stuff.gameObject, item));
        }


    }



    private RectTransform SetAnchor(RectTransform t)
    {
        RectTransform pt = t.parent as RectTransform;
        Vector2 newAnchorsMin = new Vector2(t.anchorMin.x + t.offsetMin.x / pt.rect.width,
                                    t.anchorMin.y + t.offsetMin.y / pt.rect.height);
        Vector2 newAnchorsMax = new Vector2(t.anchorMax.x + t.offsetMax.x / pt.rect.width,
                                            t.anchorMax.y + t.offsetMax.y / pt.rect.height);

        t.anchorMin = newAnchorsMin;
        t.anchorMax = newAnchorsMax;
        t.offsetMin = t.offsetMax = new Vector2(0, 0);

        return t;
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
            Stuff_item = SetAnchor(Stuff_item);
            CalculatePointer();
        }
    }

    public void setDialogBox(GameObject DialogBox, GameObject Stuff, Item item)
    {
        DialogBox.SetActive(true);
        DialogBoxScript.SelectedItem = Stuff;
        DialogBoxScript.stuffMenu = this;

        
        Debug.Log(Stuff.GetComponent<Image>().sprite.name);
        DialogBoxScript.IconImage.texture = Stuff.GetComponent<Image>().sprite.texture;

        DialogBoxScript.NameItem.text = "Name: " + item.Information.name;
        DialogBoxScript.SetDMG(item.Information.MinDMG.ToString(), item.Information.MaxDMG.ToString());
        DialogBoxScript.Pieces.text = "Pieces: " + item.Information.Number;
        DialogBoxScript.Price.text = "Price: " + item.Information.SellPrice;
        DialogBoxScript.item = item;
       
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

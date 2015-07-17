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
	}

    void Awake()
    {

    }
	// Update is called once per frame
	void Update () {
	}

    public void AddElement()
    {
        RectTransform stuffObject = (RectTransform)Resources.Load("stuff", typeof(RectTransform)) as RectTransform;

        RectTransform Stuff = Instantiate(stuffObject);
        Stuff.parent = StuffBackground;

        Stuff.GetComponent<Button>().onClick.AddListener(() => setDialogBox(DialogBox,  Stuff.gameObject));

        Stuff.sizeDelta = CelSize;

        SetPosition(Stuff);
        Stuff = SetAnchor(Stuff);

        Stuffs.Add(Stuff);
        CalculatePointer();
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

    public void setDialogBox(GameObject DialogBox, GameObject Stuff)
    {
        DialogBox.SetActive(true);
        DialogBoxScript.SelectedItem = Stuff;
        DialogBoxScript.stuffMenu = this;
        
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

using UnityEngine;
using System.Collections;

public class ActiveWeaponsList : MonoBehaviour {

    public RectTransform Source;
    public float Spaceing;
    public Color ActiveColor;
    public Color UnActive;

    private RectTransform Main;
    private UnlockedWeapon LastActive;
    private int Head = 0;

	// Use this for initialization
	void Start () {
        Main = this.GetComponent<RectTransform>();
        IEnumerator enumerator =  PlayerData.getUnlockedWeaponEnumerator();

        while(enumerator.MoveNext())
        {

            Item item = (Item) enumerator.Current;

            RectTransform UnlockedWeapon_RT =  Instantiate(Source);

            UnlockedWeapon_RT.transform.parent = this.transform;
            UnlockedWeapon_RT.sizeDelta = Source.sizeDelta;

            UnlockedWeapon _UnlockedWeapon = (UnlockedWeapon)UnlockedWeapon_RT.GetComponent<UnlockedWeapon>();
            _UnlockedWeapon.setItem(item);
            _UnlockedWeapon.UpdateMainImage();

            Head++;

        }


        Source.gameObject.SetActive(false);

        Debug.Log(Main.transform.childCount);
       // Source.gameObject.SetActive(false);
        ScaleContent();
        RePosition(Main);
       // Main = AnchorOpertion.SetAnchor(Main);
        Main.transform.parent.transform.parent.gameObject.SetActive(false);
	}


    private void ScaleContent()
    {

        GameObject tmpObject = new GameObject("TMP_ActiveWeapons");
        SetParentChild(Main.gameObject, tmpObject);

        float ScaleSize = Source.rect.height * (Head - 1) + Spaceing;
        Main.sizeDelta = new Vector2(Main.sizeDelta.x, Main.sizeDelta.y + ScaleSize);

        Main.transform.position = new Vector3( Main.transform.position.x,
                                               Main.transform.position.y - ScaleSize / 2,
                                               Main.transform.position.z);

        SetParentChild(tmpObject, Main.gameObject);

        Destroy(tmpObject);

    }

    public void RePosition(RectTransform SourceObject)
    {
        Head = 0;
        for (int i = 0; i < SourceObject.transform.childCount; i++)
        {
            RectTransform UnlockedWeapon_RT = SourceObject.transform.GetChild(i) as RectTransform;

            if (UnlockedWeapon_RT.gameObject.activeInHierarchy == false)
            {
                if (SourceObject.transform.childCount <= i + 1) ;
                continue;
            }

            UnlockedWeapon_RT.transform.position = new Vector3(SourceObject.position.x,
                                                        ((SourceObject.position.y + SourceObject.rect.height / 2)) - ((Source.rect.height * Head) + Source.rect.height / 2) - Spaceing,
                                                        Source.position.z);

            UnlockedWeapon_RT = AnchorOpertion.SetAnchor(UnlockedWeapon_RT);

            Head++;

        }
    }

    private void SetParentChild(GameObject Source, GameObject Destinity)
    {

        int SizeChild = Source.transform.childCount;

        while(Source.transform.childCount > 0 )
        {
            Source.transform.GetChild(0).parent = Destinity.transform;
        }
    }

    public void AddNew(Item item)
    {
        Main.transform.parent.transform.parent.gameObject.SetActive(true);
        Source.gameObject.SetActive(true);
        RectTransform UnlockedWeapon_RT = Instantiate(Source);
        UnlockedWeapon_RT.transform.parent = this.transform;

        UnlockedWeapon_RT.sizeDelta = Source.sizeDelta;

        item.isUnlocked = true;

        UnlockedWeapon UnlockedWeapon = (UnlockedWeapon)UnlockedWeapon_RT.GetComponent<UnlockedWeapon>();
        UnlockedWeapon.setItem(item);

        Head++;

        Source.gameObject.SetActive(false);

        ScaleContent();
        RePosition(Main);
        Main.transform.parent.transform.parent.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void SetWorkStationInformation(WorkStation Station)
    {
        for(int i = 0; i < Main.transform.childCount; i++)
        {
            UnlockedWeapon UW = Main.transform.GetChild(i).GetComponent<UnlockedWeapon>();
            if (UW.gameObject.activeInHierarchy == false) continue;
            if (Station.CraftingItem.Information.getID() == UW.getItem().Information.getID())
            {
                if (LastActive != null)
                {
                    LastActive.SetAsDeselect(UnActive);
                }

                UW.SetAsActive(ActiveColor);
                LastActive = UW;
                Debug.Log("Ustawiam aktywy kolor");
            }

            UW.StartCraftButton.onClick.AddListener(() => UW.ChangeCraftItem(Station) );
            UW.StartCraftButton.onClick.AddListener(() => Deselect());
            UW.StartCraftButton.onClick.AddListener(() => UW.SetAsActive(ActiveColor) );
            UW.StartCraftButton.onClick.AddListener(() => setLastActive(UW));
            
        }
    }

    public void Deselect()
    {
        LastActive.SetAsDeselect(UnActive);
    }

    public void setLastActive(UnlockedWeapon unlocked)
    {
        LastActive = unlocked;
    }
}

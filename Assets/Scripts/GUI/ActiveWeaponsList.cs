using UnityEngine;
using System.Collections;

public class ActiveWeaponsList : MonoBehaviour {

    public RectTransform Source;
    public float Spaceing;

    private RectTransform Main;
    private int Head = 0;

	// Use this for initialization
	void Start () {
        Main = this.GetComponent<RectTransform>();
        Debug.Log("TEST :D");
        IEnumerator enumerator =  PlayerData.getUnlockedWeaponEnumerator();

        while(enumerator.MoveNext())
        {

            Item item = (Item) enumerator.Current;

            RectTransform UnlockedWeapon_RT =  Instantiate(Source);
            UnlockedWeapon_RT.transform.parent = this.transform;

            UnlockedWeapon_RT.sizeDelta = Source.sizeDelta;

            UnlockedWeapon UnlockedWeapon = (UnlockedWeapon)UnlockedWeapon_RT.GetComponent<UnlockedWeapon>();
            UnlockedWeapon.setItem(item);

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

    private void RePosition(RectTransform SourceObject)
    {
        Head = 0;
        for (int i = 0; i < SourceObject.transform.childCount; i++)
        {
            RectTransform UnlockedWeapon_RT = SourceObject.transform.GetChild(i) as RectTransform;

            if (UnlockedWeapon_RT.gameObject.active == false && SourceObject.transform.GetChild(i + 1) != null) continue;

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
        Source.gameObject.SetActive(true);
        RectTransform UnlockedWeapon_RT = Instantiate(Source);
        UnlockedWeapon_RT.transform.parent = this.transform;

        UnlockedWeapon_RT.sizeDelta = Source.sizeDelta;

        UnlockedWeapon UnlockedWeapon = (UnlockedWeapon)UnlockedWeapon_RT.GetComponent<UnlockedWeapon>();
        UnlockedWeapon.setItem(item);

        Head++;

        Source.gameObject.SetActive(false);

        ScaleContent();
        RePosition(Main);
    }
	
	// Update is called once per frame
	void Update () {

	}
}

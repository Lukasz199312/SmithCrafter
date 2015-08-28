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

            UnlockedWeapon_RT.transform.position = new Vector3(Source.position.x,
                                                                    Source.position.y - (Head * (Source.rect.height + Spaceing)),
                                                                    Source.position.z);


            UnlockedWeapon_RT = AnchorOpertion.SetAnchor(UnlockedWeapon_RT);

            UnlockedWeapon UnlockedWeapon = (UnlockedWeapon)UnlockedWeapon_RT.GetComponent<UnlockedWeapon>();
            UnlockedWeapon.setItem(item);

            Head++;

        }

        Source.gameObject.SetActive(false);
        ScaleContent();
	}

    private void ScaleContent()
    {

        SetParentChild(null);
        float ScaleSize = Source.rect.height * Head;
        Main.sizeDelta = new Vector2(Main.sizeDelta.x, Main.sizeDelta.y + ScaleSize);
        SetParentChild(Main.transform);
    }

    private void SetParentChild(Transform parent)
    {
       // foreach(GameObject ChildObject in gameObject.GetComponentsInChildren( , false ));
       // {
         //   ChildObject.transform.parent = parent;
        //}
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

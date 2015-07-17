using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogBox : MonoBehaviour {

    public Button Sell;
    public Button Sell_ALL;
    public GameObject SelectedItem;
    public StuffMenu stuffMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Sell_Stuff()
    {
        this.gameObject.SetActive(false);
        stuffMenu.test();
        Destroy(SelectedItem);
    }
}

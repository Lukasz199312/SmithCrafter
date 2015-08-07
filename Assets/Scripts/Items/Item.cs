using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public ItemInformation Information;

	// Use this for initialization
	void Start () {
       // Information = GetComponent<ItemInformation>();
        if (Information == null) Information = new ItemInformation();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    ItemInformation Information;

	// Use this for initialization
	void Start () {
        Information = GetComponent<ItemInformation>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

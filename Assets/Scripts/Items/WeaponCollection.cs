using UnityEngine;
using System.Collections;
using System;

public class WeaponCollection : MonoBehaviour {

    public Item[] WeaponsList;

	// Use this for initialization
	void Start () {

        int ID = 0;
        foreach (Item Weapon in WeaponsList)
        {
            Weapon.Information.SetID(ID);
            ID++;
        }

        PlayerData.setWeaponList(this);

	}
	
	// Update is called once per frame
	void Update () {
	
	}


}

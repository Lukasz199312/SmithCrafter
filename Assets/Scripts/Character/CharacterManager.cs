using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Character;
using Assets.Scripts.Views;

public class CharacterManager : MonoBehaviour
{
    List<CharacterAction> CharacterList = new List<CharacterAction>();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void add(CharacterAction Characterobject)
    {
        CharacterList.Add(Characterobject);
    }

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourcesManager : MonoBehaviour {

    public ResourceElemnt[] Text;

	// Use this for initialization
	void Start () {
        PlayerData.setResourcesManager(this);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void UpdateAll()
    {
        foreach (ResourceElemnt Element in Text)
        {
            Element.UpdateResource();
        }
    }

}

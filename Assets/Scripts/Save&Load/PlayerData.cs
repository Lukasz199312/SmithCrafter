using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

    public static string Time;
    public static int CharacterCount;
    public static int Gold;
    public static int IronOre;
    public static int SilverOre;
    public static int GoldOre;
    public static int Diamond;

    private static ResourcesManager Resources;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public static void setResourcesManager(ResourcesManager RM)
    {
        Resources = RM;
    }

    public static void UpdateResources(){
        Resources.UpdateAll();
    }
}

using UnityEngine;
using System.Collections;

public class PopMenu : MonoBehaviour {

   public enum PositionPopMenu
    {
        LEFT, RIGHT, TOP, BOT
    };

    public GameObject Menu;
    public GameObject Root;
    public PositionPopMenu Position;
    public float Space = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowMenu()
    {
        Vector3 PositionNewMenu = CheckPosition();
        GameObject NewMenu = Instantiate(Menu, PositionNewMenu, Quaternion.identity) as GameObject;
        NewMenu.transform.parent = Root.transform.parent.transform;
        
        Debug.Log("Test");
    }

    private Vector3 CheckPosition()
    {
        switch (Position)
        {
            case PositionPopMenu.BOT:
                return new Vector3(Root.transform.position.x, Root.transform.position.y + Space, Root.transform.position.z);
                break;

            case PositionPopMenu.RIGHT:
                return new Vector3(Root.transform.position.x + Space, Root.transform.position.y, Root.transform.position.z);
                break;
            default:
                return Root.transform.position;
                break;
        }
    }
}

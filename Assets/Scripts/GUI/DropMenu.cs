using UnityEngine;
using System.Collections;

public class DropMenu : MonoBehaviour {

    public Canvas Menu;

    public Canvas BuyMenu;
    public Canvas EmptyStationMenu;
    public Canvas WorkStationMenu;

    private ViewsManager _ViewsManager;
    private GameObject SelectedObject;
    private CanvasGroup canvasgroup;
    private Animator anim;
    private bool isMenuOpen = false;

	// Use this for initialization
	void Start () {
        _ViewsManager = GetComponent<ViewsManager>();
        canvasgroup = Menu.GetComponent<CanvasGroup>();
        anim = Menu.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        GameObject Object = _ViewsManager.Touch_Action.Touch.SelectedGameObject;
        if (object.Equals(Object, SelectedObject) == false && isMenuOpen == false)
        {
            switch (Object.tag)
            {
                case "BuyStation":
                    Menu.enabled = false;
                    Menu = BuyMenu;
                    anim = Menu.GetComponent<Animator>();
                    Menu.enabled = true;
                    break;

                case "WorkStation":
                    Menu.enabled = false;
                    Menu = WorkStationMenu;
                    anim = Menu.GetComponent<Animator>();
                    Menu.enabled = true;
                    break;
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Exit"))
            {
                SelectedObject = _ViewsManager.Touch_Action.Touch.SelectedGameObject;
                canvasgroup.alpha = 1f;
                Menu.transform.position = SelectedObject.transform.position;
                anim.SetBool("Start", true);
                isMenuOpen = true;
                _ViewsManager.Touch_Action.Touch.Mask = 1 << 4;
               // _ViewsManager.Touch_Action.Swap.Enabled = false;
            }
            else
            {
                _ViewsManager.Touch_Action.Touch.UntachedObject();
               _ViewsManager.Touch_Action.Swap.Enabled = true;
            }
        }
    }

    public void ToggleOffMenu()
    {
        if (isMenuOpen == true)
        {
            Debug.Log("Close Menu");
            SelectedObject = null;
            anim.SetBool("Start", false);
            isMenuOpen = false;
            _ViewsManager.Touch_Action.Touch.Mask = -1;

        }
    }

    
}

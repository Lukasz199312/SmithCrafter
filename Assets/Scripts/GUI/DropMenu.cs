using UnityEngine;
using System.Collections;

public class DropMenu : MonoBehaviour {

    public Canvas Menu;

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

        if (object.Equals(SelectedObject, _ViewsManager.Touch_Action.SelectedObject) == false && isMenuOpen == false)
        {
            //canvasgroup.alpha = 1f;
            SelectedObject =  _ViewsManager.Touch_Action.SelectedObject;
            Menu.transform.position = SelectedObject.transform.position;
            anim.SetBool("Start", true);
            isMenuOpen = true;
            _ViewsManager.Touch_Action.Swap = TouchAction.SwapState.DISABLED;
        }
    }

    public void ToggleOffMenu()
    {

        if (isMenuOpen == true)
        {
            canvasgroup.alpha = 0;
            _ViewsManager.Touch_Action.UntouchedObject();
            SelectedObject = null;
            // Menu.transform.position = new Vector3(0, 0, Menu.transform.position.z);
            anim.SetBool("Start", false);
            isMenuOpen = false;
            _ViewsManager.Touch_Action.Swap = TouchAction.SwapState.ENABLED;
        }
    }
}

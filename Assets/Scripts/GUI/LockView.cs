using UnityEngine;
using System.Collections;
using Assets.Scripts.Views;

public class LockView : MonoBehaviour {

    public ViewsManager ViewManager;
    public GameObject BuyViewPanel;
    private View[] Views;
	// Use this for initialization
	void Start () {
        Views = new View[ViewManager.Views.Length];

        for (int i = 0; i < Views.Length; i++)
        {
           Views[i] = new View();
           Views[i] =  ViewManager.Views[i].GetComponent<View>();
        }


	}
	
	// Update is called once per frame
	void Update () {
        if (Views[ViewManager.CurrentView].IsActive == false)
        {
            BuyViewPanel.SetActive(true);
            ViewManager.Touch_Action.Touch.Mask = 1 << 4;
        }
        else
        {
            BuyViewPanel.SetActive(false);
            ViewManager.Touch_Action.Touch.Mask = -1;
        }
	}
}

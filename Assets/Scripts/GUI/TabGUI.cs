using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TabGUI : MonoBehaviour {

    public float SelectedTabSize;

    public GameObject Scroll_TAB;
    public GameObject Character_TAB;

    private Button Button_Scroll;
    private Button Button_Character;

    private Button SelectecTab;

	// Use this for initialization
	void Start () {
        Button_Scroll = (Button)Scroll_TAB.GetComponent<Button>();
        Button_Character = (Button)Character_TAB.GetComponent<Button>();

        AcitaveTab(Button_Scroll);
        SelectecTab = Button_Scroll;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void SetSelectedTab(GameObject Button){
        if (object.Equals(Button, Scroll_TAB))
        {
            if (object.Equals(Button_Scroll, SelectecTab)) return;
            AcitaveTab(Button_Scroll);
            InAcitaveTab(Button_Character);
            SelectecTab = Button_Scroll;

        }
        else if (object.Equals(Button, Character_TAB))
        {
            if (object.Equals(Button_Character, SelectecTab)) return;
            AcitaveTab(Button_Character);
            InAcitaveTab(Button_Scroll);
            SelectecTab = Button_Character;
        }

    }

    private void AcitaveTab(Button button)
    {
        RectTransform Button_rect = button.GetComponent<RectTransform>();

        Color SelectedColor;
        Color.TryParseHexString("FFFFFFFF", out SelectedColor);

        button.image.color = SelectedColor;

        Button_rect.sizeDelta = new Vector2(Button_rect.sizeDelta.x, Button_rect.sizeDelta.y + SelectedTabSize);

        Button_rect.transform.position = new Vector3(Button_rect.transform.position.x,
                                                     Button_rect.transform.position.y + SelectedTabSize / 2,
                                                     Button_rect.transform.position.z);
    }

    private void InAcitaveTab(Button button)
    {
        RectTransform Button_rect = button.GetComponent<RectTransform>();

        Color SelectedColor;
        Color.TryParseHexString("E4E4E4FF", out SelectedColor);

        button.image.color = SelectedColor;

        Button_rect.sizeDelta = new Vector2(Button_rect.sizeDelta.x, Button_rect.sizeDelta.y - SelectedTabSize);

        Button_rect.transform.position = new Vector3(Button_rect.transform.position.x,
                                                     Button_rect.transform.position.y - SelectedTabSize / 2,
                                                     Button_rect.transform.position.z);
    }

}

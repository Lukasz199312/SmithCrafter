using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TabGUI : MonoBehaviour {

    public float SelectedTabSize;

    public GameObject Scroll_TAB;
    public GameObject Character_TAB;

    private Button Button_Scroll;
    private Button Button_Character;

	// Use this for initialization
	void Start () {
        Button_Scroll = (Button)Scroll_TAB.GetComponent<Button>();
        Button_Character = (Button)Character_TAB.GetComponent<Button>();

        Color SelectedColor;
        Color.TryParseHexString("E4E4E4FF",out SelectedColor);

        Button_Scroll.image.color = SelectedColor;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void SetSelectedTab(GameObject Button){
        if (object.Equals(Button, Scroll_TAB))
        {
            AcitaveTab(Button_Scroll);

        }
        else if (object.Equals(Button, Character_TAB))
        {
            RectTransform Button_rect = Button_Character.GetComponent<RectTransform>();
            RectTransform Rect_Scroll = Button_Scroll.GetComponent<RectTransform>();

            Rect_Scroll.sizeDelta = Button_rect.sizeDelta;

            Button_rect.sizeDelta = new Vector2(Button_rect.sizeDelta.x, Button_rect.sizeDelta.y + SelectedTabSize);
            Button_rect.transform.position = new Vector3(Button_rect.transform.position.x,
                                                         Button_rect.transform.position.y + SelectedTabSize / 2,
                                                         Button_rect.transform.position.z);
        }

    }

    private void AcitaveTab(Button button)
    {
        RectTransform Button_rect = button.GetComponent<RectTransform>();

        Button_rect.sizeDelta = new Vector2(Button_rect.sizeDelta.x, Button_rect.sizeDelta.y + SelectedTabSize);

        Button_rect.transform.position = new Vector3(Button_rect.transform.position.x,
                                                     Button_rect.transform.position.y + SelectedTabSize / 2,
                                                     Button_rect.transform.position.z);
    }

    private void InAcitaveTab(Button button)
    {
        RectTransform Button_rect = button.GetComponent<RectTransform>();

        Button_rect.sizeDelta = new Vector2(Button_rect.sizeDelta.x, Button_rect.sizeDelta.y + SelectedTabSize);

        Button_rect.transform.position = new Vector3(Button_rect.transform.position.x,
                                                     Button_rect.transform.position.y + SelectedTabSize / 2,
                                                     Button_rect.transform.position.z);
    }
}

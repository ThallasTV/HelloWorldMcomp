using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircularMenu : MonoBehaviour
{
    public List<MenuButton> buttons = new List<MenuButton>();
    private Vector2 MousePosition;
    private Vector2 fromVector2M = new Vector2(0.5f, 1.0f);
    private Vector2 centercircle = new Vector2(0.5f, 0.5f);
    private Vector2 toVector2M;

    public int menuItems;
    public int CurrentMenuItem;
    private int OldMenuItem;
    // Start is called before the first frame update
    void Start()
    {
        menuItems = buttons.Count;
        foreach(MenuButton button in buttons)
        {
            button.sceneImage.color = Color.clear;
        }
        CurrentMenuItem = 0;
        OldMenuItem = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentMenuItem();
        if (Input.GetButtonDown("Fire1")) 
            ButtonAction();
    }

    public void GetCurrentMenuItem()
    {
        MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        toVector2M = new Vector2(MousePosition.x / Screen.width, MousePosition.y / Screen.height);
        float angle = -((Mathf.Atan2(fromVector2M.y - centercircle.y, fromVector2M.x - centercircle.x) -
                        Mathf.Atan2(toVector2M.y - centercircle.y, toVector2M.x - centercircle.x) *
                        Mathf.Rad2Deg));

        if (angle < 0)
            angle += 360;

        Debug.Log("menu items: " + menuItems);
        CurrentMenuItem = (int)(angle / (360 / menuItems));

        if (CurrentMenuItem != OldMenuItem)
        {
            buttons[OldMenuItem].sceneImage.color = Color.clear;
            OldMenuItem = CurrentMenuItem;
            buttons[CurrentMenuItem].sceneImage.color = buttons[CurrentMenuItem].HighlightedColor;
        }
    }
    public void ButtonAction()
    {
        buttons[CurrentMenuItem].sceneImage.color = buttons[CurrentMenuItem].PressedColor;
        if (CurrentMenuItem == 0)
        {
            print ("You have pressed the first button. ");
        }
    }

    [System.Serializable]
    public class MenuButton
    {
        public string Name;
        public Image sceneImage;
        public Color NormalColor;
        public Color HighlightedColor;
        public Color PressedColor;
    }
}

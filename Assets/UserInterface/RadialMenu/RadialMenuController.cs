using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RadialMenuController : MonoBehaviour
{
    //create a list to store all child buttons that are attached to the main button
    List<Button> childButtons = new List<Button>();
    //checks if the main button is opened
    bool open = false;
    //initial distance between main button and any of the child buttons
    //increase if more buttons needed else it can be lowered
    int buttonDistance = 4;
    //the speed of the buttons travelling from main button to buttonGoalPos
    float speed = 3.0f;
    //array of child buttons' destinated position after menu is opened
    Vector2[] buttonGoalPos;
    void Start()
    {
        //get all child button components that are attached to main button but filtering out the parent object(main button)
        childButtons = this.GetComponentsInChildren<Button>(true).
                            Where(x => x.gameObject.transform.parent != transform.parent).ToList();
        //also filter out default2 buttons, can use line above if there aren't any child buttons inside child buttons
        //childButtons = GetTopLevelChildren(transform);

        //setting buttonGoalPos's size to be the amount of child buttons
        buttonGoalPos = new Vector2[childButtons.Count];
        //to call the OpenMenu() function on start instead of adding it manually in the inspector
        this.GetComponent<Button>().onClick.AddListener(() => { OpenMenu(); });

        //center pivot point
        this.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);

        foreach (Button b in childButtons)
        {
            b.gameObject.transform.position = this.transform.position;
            b.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            b.gameObject.SetActive(false);
        }
    }

    public void OpenMenu()
    {
        //true false switch instead of setting it to one side
        open = !open;
        //angle for each child button to be spreaded, calculating the gap between each button
        //-1 for first button placed at vertical axis
        //final one placed at horizontal axis
        float angle = 90 / (childButtons.Count - 1) * Mathf.Deg2Rad;
        //check each child button
        for (int i = 0; i < childButtons.Count; i++)
        {
            if (open)
            {
                //calculating where each child button's (x.y) position should be placed
                float xPos = Mathf.Cos(angle * i) * buttonDistance;
                float yPos = Mathf.Sin(angle * i) * buttonDistance;
                
                buttonGoalPos[i] = new Vector2(this.transform.position.x + xPos, this.transform.position.y + yPos);
            }
            else 
                buttonGoalPos[i] = this.transform.position;
        }
        StartCoroutine(MoveButtons());
    }

    private IEnumerator MoveButtons()
    {
        foreach (Button b in childButtons)
            b.gameObject.SetActive(true);
        int loops = 0;
        while (loops <= buttonDistance/speed)
        {
            yield return new WaitForSeconds(0.01f);
            for (int i = 0; i < childButtons.Count; i++)
            {
                Color c = childButtons[i].gameObject.GetComponent<Image>().color;
                if (open)
                    c.a = Mathf.Lerp(c.a, 1, speed * Time.deltaTime);
                else
                    c.a = Mathf.Lerp(c.a, 0, speed * Time.deltaTime);

                childButtons[i].gameObject.GetComponent<Image>().color = c;
                childButtons[i].gameObject.transform.position = Vector2.Lerp(childButtons[i].gameObject.transform.position, buttonGoalPos[i], speed * Time.deltaTime);
            }
            loops++;
        }
        if (!open)
        {
            foreach (Button b in childButtons)
                b.gameObject.SetActive(false);
        }
    }

}

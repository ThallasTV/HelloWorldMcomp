using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Spell : MonoBehaviour
{
    [HideInInspector]
    List<Button> childButtons = new List<Button>();
    public GameObject spells;
    bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        childButtons = spells.GetComponentsInChildren<Button>(true).
                        Where(x => x.gameObject.transform.parent != transform.parent).ToList();
        this.GetComponent<Button>().onClick.AddListener(() => { OpenSpells(); });
        spells.SetActive(false);

    }

    public void OpenSpells()
    {
        open = !open;
        spells.SetActive(open);
    }
    public void CallRain()
    {
        //bring clouds and rain
    }
}

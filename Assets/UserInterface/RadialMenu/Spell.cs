using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    public GameObject spells;
    public Button rainButton;
    bool open = false;

    // Start is called before the first frame update
    void Start()
    {
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

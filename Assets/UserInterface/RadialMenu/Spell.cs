using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    public GameObject spells;
    public Button rainButton;
    public GameObject rain;

    bool open = false;
    bool raining = false;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => { OpenSpells(); });
        rainButton.GetComponent<Button>().onClick.AddListener(() => { CallRain(); });
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
        //just put rain first
        raining = !raining;
        rain.SetActive(raining);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    public GameObject spells;
    public Button rainButton;
    public Button meteorButton;
    public GameObject rain;
    GameObject[] clouds;
    public GameObject meteor;

    bool open = false;
    bool raining = false;
    float rainTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => { OpenSpells(); });
        rainButton.GetComponent<Button>().onClick.AddListener(() => { CallRain(); });
        meteorButton.GetComponent<Button>().onClick.AddListener(() => { CallMeteor(); });
        spells.SetActive(false);
    }

    public void OpenSpells()
    {
        open = !open;
        spells.SetActive(open);
    }
    public void CallRain()
    {
        //StartCoroutine(delay());
        //WaitForSeconds(rainTime);

        raining = !raining;
        rain.SetActive(raining);
    }
    /*
    IEnumerator delay()
    {
        //FIX TOMORROW
        yield return new WaitForSeconds(rainTime);
    }*/

    public void CallMeteor()
    {
        Debug.Log("HI");
    }
}

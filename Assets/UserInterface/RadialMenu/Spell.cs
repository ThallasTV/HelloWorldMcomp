using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    public GameObject spells;
    public Button rainButton;
    public Button meteorButton;
    public Button cloudButton;
    public GameObject rain;
    public GameObject cloud;
    //public GameObject meteor; //no meteor

    bool open = false;
    bool raining = false;
    //float rainTime = 3.0f;
    bool cloudBool = false;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => { OpenSpells(); });
        rainButton.GetComponent<Button>().onClick.AddListener(() => { CallRain(); });
        meteorButton.GetComponent<Button>().onClick.AddListener(() => { CallMeteor(); });
        cloudButton.GetComponent<Button>().onClick.AddListener(() => { CallCloud(); });
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
    public void CallCloud()
    {
        cloudBool = !cloudBool;
        cloud.SetActive(cloudBool);
    }
}

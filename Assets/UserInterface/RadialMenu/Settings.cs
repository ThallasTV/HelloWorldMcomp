using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    public GameObject settings;
    public Button closeButton;
    public Button saveButton;
    // Start is called before the first frame update
    void Start()
    {
        settings.SetActive(false);
        closeButton.GetComponent<Button>().onClick.AddListener(() => { CloseSettings(); });
        saveButton.GetComponent<Button>().onClick.AddListener(() => { SaveSettings(); });
        this.GetComponent<Button>().onClick.AddListener(() => { OpenSettings(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenSettings()
    {
        settings.SetActive(true);
    }
    public void CloseSettings()
    {
        settings.SetActive(false);
    }
    public void SaveSettings()
    {

    }
    

}

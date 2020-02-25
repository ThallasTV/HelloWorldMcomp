using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    public GameObject settings;
    public Button closeButton;
    public Button saveButton;
    bool open;   
    // Start is called before the first frame update
    void Start()
    {
        settings.SetActive(false);
        this.GetComponent<Button>().onClick.AddListener(() => { OpenSettings(); });
        closeButton.onClick.AddListener(() => { CloseSettings(); });
        saveButton.onClick.AddListener(() => { SaveSettings(); });
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

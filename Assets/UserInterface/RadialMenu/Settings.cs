using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Settings : MonoBehaviour
{
    public GameObject settings;
    public Slider volumeSlider;
    public TMPro.TMP_Dropdown ScreenResolutionDroppdown;
    public Button closeButton;
    public Button saveButton;
    public AudioMixer audioMixer;
    public int resolutionIndex;
    float volume = -80.0f;

    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        settings.SetActive(false);
        closeButton.GetComponent<Button>().onClick.AddListener(() => { CloseSettings(); });
        saveButton.GetComponent<Button>().onClick.AddListener(() => { SaveSettings(); });
        this.GetComponent<Button>().onClick.AddListener(() => { OpenSettings(); });
        volumeSlider.GetComponent<Slider>().onValueChanged.AddListener(delegate { setVolume(volume); });
        ScreenResolutionDroppdown.GetComponent<TMPro.TMP_Dropdown>().onValueChanged.AddListener(delegate { setResolution(); });


        resolutions = Screen.resolutions;
        ScreenResolutionDroppdown.ClearOptions();
        List<string> resolutionOptions = new List<string>();
        int currResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionOption = resolutions[i].width + "x" + resolutions[i].height;
            resolutionOptions.Add(resolutionOption);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) 
                    currResolutionIndex = i;
        }
        ScreenResolutionDroppdown.AddOptions(resolutionOptions);
        ScreenResolutionDroppdown.value = currResolutionIndex;
        ScreenResolutionDroppdown.RefreshShownValue();
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
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void setResolution()
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}

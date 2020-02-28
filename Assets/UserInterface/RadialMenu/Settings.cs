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
    public Toggle screenModeToggle;
    public Button closeButton;
    public Button saveButton;
    public AudioMixer audioMixer;
    float volume = -80.0f;
    bool isFullScreen = true;

    List<Resolution> resolutions = new List<Resolution>();
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        settings.SetActive(false);

        screenSettings();
        setResolution(resolutions.Count - 1);

        ScreenResolutionDroppdown.onValueChanged.AddListener(delegate { setResolution(ScreenResolutionDroppdown.value); });
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
        //fake button
    }
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void screenSettings()
    {
        Resolution[] tempResolutions = Screen.resolutions;

        List<string> resolutionOptions = new List<string>();

        for (int i = 0; i < tempResolutions.Length; i++)
        {
            if (tempResolutions[i].width >= 1024)
                resolutions.Add(tempResolutions[i]);
        }

        int currResolutionIndex = 0;
        for (int i = 0; i < resolutions.Count; i++)
        {
            string resolutionOption = resolutions[i].width + "x" + resolutions[i].height + " @ " + resolutions[i].refreshRate + "Hz";

            resolutionOptions.Add(resolutionOption);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                currResolutionIndex = i;
        }
        ScreenResolutionDroppdown.AddOptions(resolutionOptions);
        ScreenResolutionDroppdown.value = currResolutionIndex;
        ScreenResolutionDroppdown.RefreshShownValue();
    }
    public void setScreenMode()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
        Debug.Log(isFullScreen);
    }
}

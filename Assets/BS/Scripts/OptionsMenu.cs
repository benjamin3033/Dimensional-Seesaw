using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider sensitivitySlider = null;
    public Text sensitivityText = null;

    public Dropdown FullscreenDropdown = null;
    public Dropdown ResolutionDropdown = null;

    Resolution[] resolutions;

    string ResToString(Resolution res)
    {
        return res.width + " x " + res.height;
    }

    private void Start()
    {
        sensitivityText.text = "" + (int)sensitivitySlider.value;

        FullscreenDropdown.onValueChanged.AddListener(delegate { FullscreenDropdownValueChanged(FullscreenDropdown); });
        

        SetupResolutions();
    }

    private void SetupResolutions()
    {
        resolutions = Screen.resolutions;
        ResolutionDropdown.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions[ResolutionDropdown.value].width, resolutions[ResolutionDropdown.value].height, false); });

        for (int i = 0; i < resolutions.Length; i++)
        {
            ResolutionDropdown.options[i].text = ResToString(resolutions[i]);
            ResolutionDropdown.value = i;
            if(i < resolutions.Length-1)
            {
                ResolutionDropdown.options.Add(new Dropdown.OptionData(ResolutionDropdown.options[i].text));
            }
        }

        
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode = FullScreenMode.Windowed);
    }

    void FullscreenDropdownValueChanged(Dropdown change)
    {
        switch(change.value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;

            case 1:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;

            case 2:
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
                break;

            case 3:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
        }
    }

    void ResolutionDropdownValueChanged(Dropdown change)
    {
        SetResolution(change.value);
    }

    public void ChangeSensitivity()
    {
        sensitivityText.text = "" + (int)sensitivitySlider.value;
        Settings.sensitivity = (int)sensitivitySlider.value * 100;
    }
}
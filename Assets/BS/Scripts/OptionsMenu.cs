using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class OptionsMenu : MonoBehaviour
{
    public Slider sensitivitySlider = null;
    public Text sensitivityText = null;

    public Dropdown FullscreenDropdown = null;
    public Dropdown ResolutionDropdown = null;

    Resolution[] resolutions;

    private void Start()
    {
        sensitivityText.text = "" + (int)sensitivitySlider.value;
        FullscreenDropdown.onValueChanged.AddListener(delegate { FullscreenDropdownValueChanged(FullscreenDropdown); });
        ResolutionDropdown.onValueChanged.AddListener(delegate { ResolutionDropdownValueChanged(ResolutionDropdown); });

        SetupResolutions();
    }

    private void SetupResolutions()
    {
        resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";
            options.Add(option);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
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
        Resolution resolution = resolutions[change.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ChangeSensitivity()
    {
        sensitivityText.text = "" + (int)sensitivitySlider.value;
        Settings.sensitivity = sensitivitySlider.value / 100;
    }
}
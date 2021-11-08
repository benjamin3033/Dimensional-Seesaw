using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider sensitivitySlider = null;

    public Text sensitivityText = null;

    public void ChangeSensitivity()
    {
        sensitivityText.text = "" + (int)sensitivitySlider.value;
        Settings.sensitivity = (int)sensitivitySlider.value * 100;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsTabs : MonoBehaviour
{
    public GameObject GameTab = null, ControlsTab = null, VideoTab = null, AudioTab = null;

    public void TabManager(string name)
    {
        switch(name)
        {
            case "game":
                GameTab.SetActive(true);
                ControlsTab.SetActive(false);
                VideoTab.SetActive(false);
                AudioTab.SetActive(false);
                break;

            case "controls":
                GameTab.SetActive(false);
                ControlsTab.SetActive(true);
                VideoTab.SetActive(false);
                AudioTab.SetActive(false);
                break;

            case "video":
                GameTab.SetActive(false);
                ControlsTab.SetActive(false);
                VideoTab.SetActive(true);
                AudioTab.SetActive(false);
                break;

            case "audio":
                GameTab.SetActive(false);
                ControlsTab.SetActive(false);
                VideoTab.SetActive(false);
                AudioTab.SetActive(true);
                break;
        }
    }
}

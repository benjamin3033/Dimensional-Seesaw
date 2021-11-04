using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Canvas pauseMenu = null;

    bool isPaused = false;

    private void Update()
    {
        if(Input.GetButtonUp("Cancel"))
        {
            RunPauseMenu();
        }
    }

    void RunPauseMenu()
    {
        if (isPaused)
        {
            pauseMenu.enabled = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Settings.isPaused = false;
            isPaused = false;
        }
        else
        {
            pauseMenu.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Settings.isPaused = true;
            isPaused = true;
        }
    }
}
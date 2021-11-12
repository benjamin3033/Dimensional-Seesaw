using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Canvas pauseMenu = null;

    private void Update()
    {
        Debug.Log(Settings.isPaused);
        Debug.Log(Time.timeScale);

        if(Input.GetButtonUp("Cancel"))
        {
            RunPauseMenu();
        }
    }

    private void Start()
    {
        ResumeGame();
    }

    public void ResumeGame()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Settings.isPaused = false;
    }

    void RunPauseMenu()
    {
        if (!Settings.isPaused)
        {
            pauseMenu.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Settings.isPaused = true;
        }
    }
}
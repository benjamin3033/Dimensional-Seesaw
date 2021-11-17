using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Canvas pauseMenu = null;
    float playerPausing = 0;

    private void Update()
    {
        if(playerPausing > 0.1 && !Settings.isPaused)
        {
            pauseMenu.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Settings.isPaused = true;
            playerPausing = 0;
        }
    }

    public void RecieveInput(float isPausing)
    {
        playerPausing = isPausing;
    }

    private void Start()
    {
        ResumeGame();
    }

    public void ResumeGame()
    {
        Settings.isPaused = false;
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        
    }
}
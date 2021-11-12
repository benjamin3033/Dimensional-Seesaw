using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Canvas MainMenuCanvas = null;
    public Canvas OptionsCanvas = null;
    public Canvas CreditsCanvas = null;
    public Canvas QuitConfirmationCanvas = null;

    bool optionsOn = false;
    bool creditsOn = false;
    bool quitOn = false;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        if(optionsOn)
        {
            MainMenuCanvas.enabled = true;
            OptionsCanvas.enabled = false;
            optionsOn = false;
        }
        else
        {
            MainMenuCanvas.enabled = false;
            OptionsCanvas.enabled = true;
            optionsOn = true;
        }
    }

    public void Credits()
    {
        if (creditsOn)
        {
            MainMenuCanvas.enabled = true;
            CreditsCanvas.enabled = false;
            creditsOn = false;
        }
        else
        {
            MainMenuCanvas.enabled = false;
            CreditsCanvas.enabled = true;
            creditsOn = true;
        }
    }

    public void QuitConfirmation()
    {
        if (quitOn)
        {
            MainMenuCanvas.enabled = true;
            QuitConfirmationCanvas.enabled = false;
            quitOn = false;
        }
        else
        {
            MainMenuCanvas.enabled = false;
            QuitConfirmationCanvas.enabled = true;
            quitOn = true;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}

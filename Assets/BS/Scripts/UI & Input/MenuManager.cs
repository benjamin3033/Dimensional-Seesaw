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
    public Canvas LoadingCanvas = null;

    public Slider LoadingSlider = null;

    bool optionsOn = false;
    bool creditsOn = false;
    bool quitOn = false;

    private void Update()
    {
        
    }

    public void StartGame()
    {
        LoadingCanvas.gameObject.SetActive(true);
        StartCoroutine(LoadGameAsync());
    }

    IEnumerator LoadGameAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        

        while (!asyncLoad.isDone)
        {
            LoadingSlider.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            yield return null;
        }
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

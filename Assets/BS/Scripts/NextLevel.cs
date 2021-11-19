using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public Canvas LoadingCanvas = null;
    public Slider LoadingSlider = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is calleds once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Settings.isPaused = true;
            LoadingCanvas.gameObject.SetActive(true);
            StartCoroutine(LoadGameAsync());
        }
        
    }

    IEnumerator LoadGameAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);


        while (!asyncLoad.isDone)
        {
            LoadingSlider.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            yield return null;
        }
    }
}

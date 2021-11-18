using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CameraMove : MonoBehaviour
{
    public PlayableDirector MedevalStartCut;
    public PlayableDirector ScfiStartCut;
    public PlayableDirector MedtoScf;
    public PlayableDirector ScftoMed;
    public PlayableDirector MedtoOp;
    public PlayableDirector OptoMed;
    public PlayableDirector MedtoCred;
    public PlayableDirector CredtoMed;
    public PlayableDirector MedControlstoGame;
    public PlayableDirector MedGameToControls;
    public PlayableDirector MedGameToVideo;
    public PlayableDirector MedVideoToGame;
    public PlayableDirector MedCreditToMainMenu;
    public PlayableDirector MedMainMenuToCredit;

    public PlayableDirector SciMainMenutoOptions;

    public void PlayMedevalCut()
    {
        MedevalStartCut.Play();
    }

    public void PlayScfiCut()
    {
        ScfiStartCut.Play();
    }

    public void PlaySwitchMedtoScf()
    {
        MedtoScf.Play();
    }

    public void PlaySwitchScftoMed()
    {
        ScftoMed.Play();
    }

    public void PlayMedtoOp()
    {
        MedtoOp.Play();
    }
    public void PlayOptoMed()
    {
        OptoMed.Play();
    }

    public void PlayMedControltoGame()
    {
        MedControlstoGame.Play();
    }

    public void PlayMedGameToControl()
    {
        MedGameToControls.Play();
    }

    public void PlayMedGameToVideo()
    {
        MedGameToVideo.Play();
    }

    public void PlayMedVideoToGame()
    {
        MedVideoToGame.Play();
    }
       
    public void PlayMedCreditToMainMenu()
    {
        MedCreditToMainMenu.Play();
    }

    public void PlayMedMainToCredit()
    {
        MedMainMenuToCredit.Play();
    }

    public void PlaySciFiMenutooptions()
    {
        SciMainMenutoOptions.Play();
    }    
}

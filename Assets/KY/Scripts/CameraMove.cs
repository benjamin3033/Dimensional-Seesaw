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
    public PlayableDirector SciOptionsToMenu;
    public PlayableDirector SciGametoVA;
    public PlayableDirector SciVAtoGame;
    public PlayableDirector SciGametoControls;
    public PlayableDirector SciControlstoGame;
    public PlayableDirector SciMenutoCredits;
    public PlayableDirector SciCreditstoMenu;



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
    
    public void PlaySciFiOptionsToMenu()
    {
        SciOptionsToMenu.Play();
    }
    
    public void PlaySciGametoVA()
    {
        SciGametoVA.Play();
    }


    public void PlaySciVAtoGame()
    {
        SciVAtoGame.Play();
    }

    public void PlaySciGametoControls()
    {
        SciGametoControls.Play();
    }
    
    public void PlaySciControlstoGame()
    {
        SciControlstoGame.Play();
    }

    public void PlaySciMenutoCredits()
    {
        SciMenutoCredits.Play();
    }
    
    public void PlaySciCreditstoMenu()
    {
        SciCreditstoMenu.Play();
    }

}

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
}

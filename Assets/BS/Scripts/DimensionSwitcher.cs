using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionSwitcher : MonoBehaviour
{
    bool isOld = true;
    public PlayerMovement movementScript = null;
    public CharacterController charCont = null;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("DimensionSwitch") && !Settings.isPaused)
        {
            SwitchDim();
        }    
    }

    void SwitchDim()
    {
        if(isOld)
        {
            charCont.enabled = false;
            transform.position = new Vector3(transform.position.x - 100, transform.position.y, transform.position.z);
            charCont.enabled = true;
            isOld = false;
        }
        else
        {
            charCont.enabled = false;
            transform.position = new Vector3(transform.position.x + 100, transform.position.y, transform.position.z);
            charCont.enabled = true;
            isOld = true;
        }
    }
}

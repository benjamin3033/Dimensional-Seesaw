using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionSwitcher : MonoBehaviour
{
    bool isOld = true;
    public PlayerMovement movementScript = null;
    public CharacterController charCont = null;

    float playerSwitching = 0;
    public float TimeBetweenSwitching = 1f;
    float switchingTimer;
    bool canSwitch = false;

    // Update is called once per frame
    void Update()
    {
        if(playerSwitching > 0.1 && !Settings.isPaused && canSwitch)
        {
            SwitchDim();
            canSwitch = false;
        }
        else if (!canSwitch)
        {
            if (switchingTimer > 0)
            {
                switchingTimer -= Time.deltaTime;
            }
            else
            {
                switchingTimer = TimeBetweenSwitching;
                canSwitch = true;
            }
        }
    }

    public void RecieveSwitchInput(float isSwitching)
    {
        playerSwitching = isSwitching;
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

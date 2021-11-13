using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
#pragma warning disable 649

    [SerializeField] PlayerMovement movement;
    [SerializeField] PlayerLook mouseLook;
    [SerializeField] WeaponShooting weaponShooting;
    [SerializeField] DimensionSwitcher dimSwitcher;
    [SerializeField] GameObject HUDAndUI = null;

    

    PlayerInput controls;
    PlayerInput.CharacterControlsActions groundMovement;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    float isShooting = 0;
    float isSwitching = 0;
    float isDimSwitching = 0;
    float isPausing = 0;

    private void Awake()
    {
        ;

        controls = new PlayerInput();
        groundMovement = controls.CharacterControls;

        groundMovement.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.Jump.performed += _ => movement.OnJumpPressed();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

        groundMovement.Shoot.performed += ctx => isShooting = ctx.ReadValue<float>();
        groundMovement.SwitchWeapon.performed += ctx => isSwitching = ctx.ReadValue<float>();

        groundMovement.SwitchDimension.performed += ctx => isDimSwitching = ctx.ReadValue<float>();

        groundMovement.Pause.performed += ctx => isPausing = ctx.ReadValue<float>();
    }

    private void Update()
    {
        if (!Settings.isPaused)
        {
            movement.RecieveInput(horizontalInput);
            mouseLook.ReceiveInput(mouseInput);
            weaponShooting.RecieveShootingInput(isShooting);
            weaponShooting.RecieveSwitchInput(isSwitching);
            dimSwitcher.RecieveSwitchInput(isDimSwitching);
            HUDAndUI.GetComponent<PauseManager>().RecieveInput(isPausing);
        } 
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}

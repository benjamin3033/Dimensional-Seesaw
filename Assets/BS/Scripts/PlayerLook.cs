using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
#pragma warning disable 649

    public Camera fpsCamera = null;
    public Transform playerCamera;

    float mouseX, mouseY;
    float xRotation = 0f;


    void Start()
    {
        fpsCamera.fieldOfView = Settings.cameraFov;
    }

    private void Update()
    {
        if(Settings.isPaused)
        {
            mouseX = 0;
            mouseY = 0;
        }

        transform.Rotate(Vector3.up, mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }

    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * Settings.sensitivity;
        mouseY = mouseInput.y * Settings.sensitivity;
    }
}

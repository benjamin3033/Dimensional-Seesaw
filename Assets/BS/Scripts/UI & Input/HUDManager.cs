using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text PlayerHealthText = null;
    public GameObject PlayerController = null;

    int playerHealth;

    private void Update()
    {
        UpdatePlayerHealth();
    }

    void UpdatePlayerHealth()
    {
        playerHealth = PlayerController.GetComponent<PlayerHealth>().Health;
        PlayerHealthText.text = "Health: " + playerHealth;
    }
}
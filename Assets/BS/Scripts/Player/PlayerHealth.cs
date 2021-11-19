using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Health > 100)
        {
            Health = 100;
        }

        if (Health <= 0)
        {
            // Die
        }
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
    }
}

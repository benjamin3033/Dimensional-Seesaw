using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyHP = 1000;
    
    float EnemyHealthPercentage;
    int CurrentHP;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = EnemyHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHP <= 0)
        {
            Destroy(gameObject);
        }

        EnemyHealthPercent();
    }

    public void EnemyHealthPercent()
    {
        EnemyHealthPercentage = (CurrentHP / EnemyHP);
        //Debug.Log(EnemyHealthPercentage);
    }

    public void UpdateHealthBar()
    {

    }

    public void TakeDamage(int amount)
    {
        CurrentHP -= amount;
        UpdateHealthBar();
    }
}

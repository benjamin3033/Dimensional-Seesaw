using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float EnemyHP = 1000;
    public RectTransform HealthPanel = null;

    float CurrentHP;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = EnemyHP;
    }

    public void TakeDamage(int amount)
    {
        CurrentHP -= amount;
        HealthPanel.anchorMax = new Vector2(CurrentHP / EnemyHP, 1);
        if (CurrentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}

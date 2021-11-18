using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int Damage = 10;
    public float lifeTime = 10f;

    PlayerHealth playerHealth;

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Player":
                playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(Damage);
                Destroy(gameObject);
                break;

            case "Object":
                Destroy(gameObject);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BulletLifeTime();
    }

    void BulletLifeTime()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

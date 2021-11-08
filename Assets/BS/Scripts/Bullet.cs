using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 10f;
    public int Damage = 10;
    public GameObject hitParticle;
    EnemyHealth EnemyHealthScript;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                EnemyHealthScript = collision.gameObject.GetComponent<EnemyHealth>();
                EnemyHealthScript.TakeDamage(Damage);
                //Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "Object":
                Instantiate(hitParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;
        }
    }

    private void Update()
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
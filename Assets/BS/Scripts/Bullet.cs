using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 10f;
    public int Damage = 10;

    public GameObject hitParticle;
    ParticleSystem LightningParticle;
    EnemyHealth EnemyHealthScript;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                LightningParticle = collision.gameObject.GetComponent<ParticleSystem>();
                LightningParticle.Play();
                EnemyHealthScript = collision.gameObject.GetComponent<EnemyHealth>();
                EnemyHealthScript.TakeDamage(Damage);
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
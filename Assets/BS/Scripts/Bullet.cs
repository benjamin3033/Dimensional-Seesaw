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

    Rigidbody m_Rigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                if(gameObject.name.Contains("Arrow"))
                {
                    Instantiate(hitParticle, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                else
                {
                    LightningParticle = collision.gameObject.GetComponent<ParticleSystem>();
                    if(LightningParticle != null)
                    {
                        LightningParticle.Play();
                    }
                    
                    Destroy(gameObject);
                }

                EnemyHealthScript = collision.gameObject.GetComponent<EnemyHealth>();
                EnemyHealthScript.TakeDamage(Damage);
                break;

            case "Object":
                if(gameObject.name.Contains("Arrow"))
                {
                    Instantiate(hitParticle, transform.position, Quaternion.identity);
                    lifeTime = 100f;
                    m_Rigidbody = gameObject.GetComponent<Rigidbody>();
                    m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    gameObject.transform.Translate(Vector3.up * 0.1f);
                }
                else
                {
                    Instantiate(hitParticle, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
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
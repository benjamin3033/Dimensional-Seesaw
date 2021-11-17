using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform ShotStart = null;
    public GameObject projectile = null;

    public float ProjectileSpeed = 1f;
    public float ProjectileRate = 1f;

    public bool PlayerInRoom = false;
    bool canShoot = true;
    float shootingTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        shootingTimer = ProjectileRate;
        gameObject.GetComponent<AIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot && gameObject.GetComponent<AIController>().CanAttack)
        {
            GameObject clone = Instantiate(projectile, ShotStart.transform.position, ShotStart.transform.rotation);
            clone.GetComponent<Rigidbody>().AddForce(ShotStart.transform.forward * ProjectileSpeed);
            canShoot = false;
        }
        else
        {
            if (shootingTimer > 0)
            {
                shootingTimer -= Time.deltaTime;
            }
            else
            {
                shootingTimer = ProjectileRate;
                canShoot = true;
            }
        }
    }
}

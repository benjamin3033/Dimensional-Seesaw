using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    public GameObject energyBall = null, bolt = null, laserGun = null, crossBow = null;
    public Transform laserBarrel = null, crossBowBarrel = null;

    GameObject bullet;
    Transform barrel;

    public float bulletSpeed = 1000f;

    bool isLaserWeapon = false;

    // Start is called before the first frame update
    void Start()
    {
        bullet = bolt;
        barrel = crossBowBarrel;
    }

    // Update is called once per frame
    void Update()
    {
        ReactToInput();
        
        if(isLaserWeapon)
        {
            laserGun.gameObject.SetActive(true);
            crossBow.gameObject.SetActive(false);
            barrel = laserBarrel;
            bullet = energyBall;
        }
        else
        {
            laserGun.gameObject.SetActive(false);
            crossBow.gameObject.SetActive(true);
            barrel = crossBowBarrel;
            bullet = bolt;
        }
    }
    void ReactToInput()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            FireBullet();
        }

        if(Input.GetButtonUp("WeaponSwitch"))
        {
            isLaserWeapon = !isLaserWeapon;
        }
    }

    void FireBullet()
    {
        GameObject clone = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
        clone.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * bulletSpeed);
    }
}
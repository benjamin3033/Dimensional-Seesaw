using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    [Header("Game Objects")] // GameObjects to be assigned in the inspector
    public GameObject laserGun = null;
    public GameObject crossBow = null;
    public GameObject energyBall = null;
    public GameObject bolt = null;
    public Transform laserBarrel = null, crossBowBarrel = null;

    [Header("Laser Gun")] // Laser gun Variables
    public float laserSpeed = 1000;
    public float LaserDelay = 1f;

    [Header("Crossbow")] // Crossbow Variables
    public float boltSpeed = 500;
    public float boltDelay = 1f;

    // Private Variables
    GameObject bullet;
    Transform barrel;
    float bulletSpeed = 0f;
    bool isLaserWeapon = false;
    bool CanFire = true;
    float ChosenTimer;
    float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        
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
            bulletSpeed = laserSpeed;
            ChosenTimer = LaserDelay;
        }
        else
        {
            laserGun.gameObject.SetActive(false);
            crossBow.gameObject.SetActive(true);
            barrel = crossBowBarrel;
            bullet = bolt;
            bulletSpeed = boltSpeed;
            ChosenTimer = boltDelay;
        }
    }
    void ReactToInput()
    {
        if (Input.GetButton("Fire1") && !Settings.isPaused && CanFire)
        {
            FireBullet();
        }
        else if (!CanFire)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = ChosenTimer;
                CanFire = true;
            }
        }

        if (Input.GetButtonUp("WeaponSwitch") && !Settings.isPaused)
        {
            isLaserWeapon = !isLaserWeapon;
        }
    }

    void FireBullet()
    {
        CanFire = false;
        GameObject clone = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
        clone.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * bulletSpeed);
    }
}
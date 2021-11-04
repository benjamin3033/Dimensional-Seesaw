using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    [Header("Game Objects")] // GameObjects to be assigned in the inspector
    [SerializeField]
    private GameObject laserGun = null;
    [SerializeField]
    private GameObject crossBow = null;
    [SerializeField]
    private GameObject energyBall = null;
    [SerializeField]
    private GameObject bolt = null;
    [SerializeField]
    private Transform laserBarrel = null, crossBowBarrel = null;

    [Header("Laser Gun")] // Laser gun Variables
    public float laserSpeed = 1000;

    [Header("Crossbow")] // Crossbow Variables
    public float boltSpeed = 500;

    // Private Variables
    GameObject bullet;
    Transform barrel;
    float bulletSpeed = 0f;
    bool isLaserWeapon = false;

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
        }
        else
        {
            laserGun.gameObject.SetActive(false);
            crossBow.gameObject.SetActive(true);
            barrel = crossBowBarrel;
            bullet = bolt;
            bulletSpeed = boltSpeed;
        }
    }
    void ReactToInput()
    {
        if (Input.GetButtonUp("Fire1") && !Settings.isPaused)
        {
            FireBullet();
        }

        if(Input.GetButtonUp("WeaponSwitch") && !Settings.isPaused)
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
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

    [Header("Recoil")]
    public Vector2 kickMinMax = new Vector2(.05f, .2f);
    public Vector2 recoilAngleMinMax = new Vector2(3, 5);
    public float recoilMoveSettleTime = .1f;
    public float recoilRotationSettleTime = .1f;

    Vector3 recoilSmoothDampVelocity;
    float recoilRotSmoothDampVelocity;
    float recoilAngle;

    [Header("Laser Gun")] // Laser gun Variables
    public float laserSpeed = 1000;
    public float LaserDelay = 1f;
    public int LaserDamage = 10;

    [Header("Crossbow")] // Crossbow Variables
    public float boltSpeed = 500;
    public float boltDelay = 1f;
    public int BoltDamage = 35;
    public GameObject ModelArrow = null;
    public GameObject PullBackRope = null;
    public GameObject RopeFired = null;

    public float WeaponSwitchSpeed = 1f;
    public int doubleDamage = 1;
    public float damageTimer;

    // Private Variables
    GameObject bullet;
    GameObject CurrentGun;
    Transform barrel;
    float bulletSpeed = 0f;
    bool isLaserWeapon = false;
    bool CanFire = true;
    bool canSwitch = false;
    float ChosenTimer;
    float shootingTimer;
    float switchingTimer;
    float playerShooting = 0;
    float playerSwitching = 0;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        CurrentGun.transform.localPosition = Vector3.SmoothDamp(CurrentGun.transform.localPosition, Vector3.zero, ref recoilSmoothDampVelocity, recoilMoveSettleTime);
    }

    // Update is called once per frame
    void Update()
    {
        ReactToInput();
        Switching();
        DamageTimer();
    }

    void Switching()
    {
        if (isLaserWeapon)
        {
            laserGun.gameObject.SetActive(true);
            crossBow.gameObject.SetActive(false);
            CurrentGun = laserGun;
            barrel = laserBarrel;
            bullet = energyBall;
            bulletSpeed = laserSpeed;
            ChosenTimer = LaserDelay;
        }
        else
        {
            laserGun.gameObject.SetActive(false);
            crossBow.gameObject.SetActive(true);
            CurrentGun = crossBow;
            barrel = crossBowBarrel;
            bullet = bolt;
            bulletSpeed = boltSpeed;
            ChosenTimer = boltDelay;
        }
    }

    public void DamageTimer()
    {
        if (damageTimer > 0)
        {
            doubleDamage = 2;
            damageTimer -= Time.deltaTime;
        }
        else
        {
            doubleDamage = 1;
        }
    }

    public void RecieveShootingInput(float isShooting)
    {
        playerShooting = isShooting;
    }

    public void RecieveSwitchInput(float isSwitching)
    {
        playerSwitching = isSwitching;
    }

    void ReactToInput()
    {
        if (playerShooting > 0.001f && !Settings.isPaused && CanFire)
        {
            CanFire = false;
            FireBullet();
            WeaponKickBack();
            shootingTimer = ChosenTimer;
        }
        else if (!CanFire)
        {
            if (shootingTimer > 0)
            {
                shootingTimer -= Time.deltaTime;
            }
            else
            {
                shootingTimer = ChosenTimer;
                CanFire = true;
                ModelArrow.SetActive(true);
                PullBackRope.SetActive(true);
                RopeFired.SetActive(false);
            }
        }

        if (playerSwitching > 0.1 && !Settings.isPaused && canSwitch)
        {
            isLaserWeapon = !isLaserWeapon;
            shootingTimer = 0;
            canSwitch = false;
        }
        else if(!canSwitch)
        {
            if(switchingTimer > 0)
            {
                switchingTimer -= Time.deltaTime;
            }
            else
            {
                switchingTimer = WeaponSwitchSpeed;
                canSwitch = true;
            }
        }
    }

    void FireBullet()
    {
        ModelArrow.SetActive(false);
        PullBackRope.SetActive(false);
        RopeFired.SetActive(true);
        GameObject clone = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
        if(isLaserWeapon)
        {
            clone.GetComponent<Bullet>().Damage = LaserDamage * doubleDamage;
        }
        else
        {
            clone.GetComponent<Bullet>().Damage = BoltDamage * doubleDamage;
        }
        
        clone.GetComponent<Rigidbody>().AddForce(barrel.transform.up * bulletSpeed);
    }

    void WeaponKickBack()
    {
        CurrentGun.transform.localPosition -= Vector3.forward * Random.Range(kickMinMax.x, kickMinMax.y);
        recoilAngle += Random.Range(recoilAngleMinMax.x, recoilAngleMinMax.y);
        recoilAngle = Mathf.Clamp(recoilAngle, 0, 30);
    }
}
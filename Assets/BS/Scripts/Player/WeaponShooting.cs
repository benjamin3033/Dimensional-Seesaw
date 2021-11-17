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

    [Header("Crossbow")] // Crossbow Variables
    public float boltSpeed = 500;
    public float boltDelay = 1f;

    public float WeaponSwitchSpeed = 1f;

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
        if (playerShooting > 0.1 && !Settings.isPaused && CanFire)
        {
            FireBullet();
            WeaponKickBack();
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
            }
        }

        if (playerSwitching > 0.1 && !Settings.isPaused && canSwitch)
        {
            isLaserWeapon = !isLaserWeapon;
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
        CanFire = false;
        GameObject clone = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
        clone.GetComponent<Rigidbody>().AddForce(barrel.transform.up * bulletSpeed);
    }

    void WeaponKickBack()
    {
        CurrentGun.transform.localPosition -= Vector3.forward * Random.Range(kickMinMax.x, kickMinMax.y);
        recoilAngle += Random.Range(recoilAngleMinMax.x, recoilAngleMinMax.y);
        recoilAngle = Mathf.Clamp(recoilAngle, 0, 30);
    }
}
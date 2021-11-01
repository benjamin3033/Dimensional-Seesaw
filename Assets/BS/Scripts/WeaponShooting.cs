using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    public GameObject bullet = null;
    public Transform barrel = null;

    public float bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject clone = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
            clone.GetComponent<Rigidbody>().AddForce(barrel.transform.position * bulletSpeed);
        }
    }
}

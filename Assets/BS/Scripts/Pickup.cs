using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
#pragma warning disable 649

    public GameObject PickupModel = null;
    [SerializeField] private Vector3 _Rotation;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    public int HealthToGive = 50;
    public float DoubleDamageLength = 2f;

    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SpinAndFloat();
    }

    private void SpinAndFloat()
    {
        PickupModel.transform.Rotate(_Rotation * Time.deltaTime);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        PickupModel.transform.position = tempPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (PickupModel.name.Contains("Medkit"))
            {
                if (other.gameObject.GetComponent<PlayerHealth>().Health < 100)
                {
                    other.gameObject.GetComponent<PlayerHealth>().Health += HealthToGive;
                    Destroy(gameObject);
                }

            }
            else if(PickupModel.name.Contains("DoubleDamage"))
            {
                other.gameObject.GetComponent<WeaponShooting>().damageTimer = DoubleDamageLength;
                Destroy(gameObject);
            }
        }
    }
}
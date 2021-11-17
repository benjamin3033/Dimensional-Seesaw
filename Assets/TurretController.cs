using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{

    public GameObject TargetPoint = null;
    public float RotationSpeed = 60f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(TargetPoint.transform);
        Vector3 toPlayer = TargetPoint.transform.position - transform.position;
        toPlayer.y = 0;
        Quaternion targetRot = Quaternion.LookRotation(toPlayer, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, RotationSpeed * Time.deltaTime);
    }
}

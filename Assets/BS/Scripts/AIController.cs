using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    NavMeshAgent agent = null;
    public GameObject TargetPoint = null;
    public bool CanAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CanAttack)
        {
            agent.SetDestination(TargetPoint.transform.position);
        }
    }
}
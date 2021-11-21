using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionZoneManager : MonoBehaviour
{
    public GameObject FutureZone = null;
    public GameObject MedievalZone = null;

    public List<GameObject> ExitDoors = new List<GameObject>();

    RoomControl futCon;
    RoomControl medCon;


    // Start is called before the first frame update
    void Start()
    {
        futCon = FutureZone.GetComponent<RoomControl>();
        medCon = MedievalZone.GetComponent<RoomControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(futCon.Enemies.Count == 0 && medCon.Enemies.Count == 0)
        {
            ExitDoors[0].gameObject.SetActive(false);
            ExitDoors[1].gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public GameObject Exit = null, Entry = null;
    public GameObject HUDManagerObject = null;

    HUDManager HudManager;

    bool EnemiesDead = false;

    public string TipString = "";

    public bool isFloatingHeadRoom;
    public bool isTurretRoom;

    // Start is called before the first frame update
    void Start()
    {
        HudManager = HUDManagerObject.GetComponent<HUDManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemies.Count <= 0 && !EnemiesDead)
        {
            if (Exit != null)
            {
                Destroy(Exit);
            }
            HudManager.SetPlayerTip("");
            EnemiesDead = true;
        }
        else
        {
            for(int i = Enemies.Count - 1; i >= 0; i--)
            {
                if(Enemies[i] == null)
                {
                    Enemies.Remove(Enemies[i]);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            HudManager.SetPlayerTip(TipString);
            if(Entry != null)
            {
                Entry.SetActive(true);
            }
            

            if(isFloatingHeadRoom)
            {
                for (int i = Enemies.Count - 1; i >= 0; i--)
                {
                    Enemies[i].GetComponent<AIController>().CanAttack = true;
                }
            }
            else if(isTurretRoom)
            {
                for (int i = Enemies.Count - 1; i >= 0; i--)
                {
                    Enemies[i].GetComponent<TurretShooting>().PlayerInRoom = true;
                }
            }
            
        }
        else if(other.tag == "Enemy")
        {
            Enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isFloatingHeadRoom)
            {
                for (int i = Enemies.Count - 1; i >= 0; i--)
                {
                    Enemies[i].GetComponent<AIController>().CanAttack = false;
                }
            }
            else if (isTurretRoom)
            {
                for (int i = Enemies.Count - 1; i >= 0; i--)
                {
                    Enemies[i].GetComponent<TurretShooting>().PlayerInRoom = false;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public GameObject Exit = null, Entry = null;

    bool EnemiesDead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Enemies.Count <= 0 && !EnemiesDead)
        {
            Destroy(Exit);
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
            Entry.SetActive(true);

            for (int i = Enemies.Count - 1; i >= 0; i--)
            {
                Enemies[i].GetComponent<AIController>().CanAttack = true;
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
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : HealthComponent
{
    Vector3 spawnPoint;
    public GameObject spawn;
    public GameObject player;
    private float timer = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.name == "Player")
        {
            spawnPoint = spawn.transform.position;
            Debug.Log(spawnPoint);
        }
    }

    private void FixedUpdate()
    {
        if (player.activeInHierarchy == false)
        {


            if(timer <= 0.0f)
            {
                Spawn();
            }
            else
            {
                timer -= Time.deltaTime;
            }
            
        }
    }

    void Spawn()
    {
        player.transform.position = spawnPoint;
        player.SetActive(true);
        timer = 2.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : HealthComponent
{
    Vector3 spawnPoint;
    public GameObject spawn;
    public GameObject player;

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
            player.transform.position = spawnPoint;

            player.SetActive(true);
        }
    }
}

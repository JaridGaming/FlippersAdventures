using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bool Triggered = false;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" || collider.name == "Player")
        {
            HealthSystem healthSystem = new HealthSystem(100);

            healthSystem.Damage(100);

            Debug.Log("Health: " + healthSystem.GetHealth());

            Triggered = true;
        }
    }
}

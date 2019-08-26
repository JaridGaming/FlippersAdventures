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

            Triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.name == "Player")
        {
            Triggered = false;
        }
    }
}

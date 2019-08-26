using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerHandler : MonoBehaviour
{
    private void Start()
    {
        HealthSystem healthSystem = new HealthSystem(100);

        Debug.Log("Health: "+healthSystem.GetHealth());
    }
}

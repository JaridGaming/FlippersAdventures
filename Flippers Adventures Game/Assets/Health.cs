using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public Transform respawnMarker = null;
    public bool triggerExplosion = false;
    public int baseDamage = 10;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            if (respawnMarker)
            {
                if (transform.GetComponent<Rigidbody>() != null)
                    transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

                transform.position = respawnMarker.position;
                currentHealth = maxHealth;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    internal void ApplyDamage(object baseDamage)
    {
        throw new NotImplementedException();
    }
}

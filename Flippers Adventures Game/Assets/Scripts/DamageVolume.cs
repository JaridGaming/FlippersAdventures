using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVolume : MonoBehaviour
{
    public float damageInterval = 1;
    private float currentInterval = 0;
    public bool targetHere = false;

    public GameObject PlayerSlot;

    void Update()
    {
        if (targetHere == true)
        {
            if (PlayerSlot.GetComponent<Health>().currentHealth > 0)
            {
                currentInterval += Time.deltaTime;
                if (currentInterval >= damageInterval)
                {
                    int baseDamage = 0;
                    PlayerSlot.GetComponent<Health>().ApplyDamage(baseDamage);
                    currentInterval = 0;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.name == "Player")
        {
            PlayerSlot = other.gameObject;
            targetHere = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            targetHere = false;
            PlayerSlot = null;
        }
    }
}

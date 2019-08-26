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
        if (other.tag == "Player")
        {
            if (other.GetComponent<Health>() != null)
            {
                PlayerSlot = other.gameObject;
                targetHere = true;
                //print(gameObject.name + " targeted " + myTarget.name + "!");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PlayerSlot)
        {
            targetHere = false;
            PlayerSlot = null;
            //print(gameObject.name + " lost its target.");
        }
    }
}

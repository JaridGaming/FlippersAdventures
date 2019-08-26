using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    int health;
    int maxHealth;

    [SerializeField]
    GameObject deathFX = null;

    void Awake()
    {
        maxHealth = health;
    }

    public virtual void ApplyDamage(int damage)
    {
        if(damage <= 0 || health <= 0)
        {
            return;
        }

        health = health - damage;

        Debug.Log("Damage hit, health now is " + health);

        if(health <= 0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        if(deathFX != null)
        {
            Instantiate(deathFX, transform.position, Quaternion.identity);
        }

        Debug.Log("HealthComponent - Death Called");
    }
}

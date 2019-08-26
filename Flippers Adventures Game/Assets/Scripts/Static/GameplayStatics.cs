using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameplayStatics
{
    public static void DealDamage(GameObject DamagedObject, int Damage)
    {
        HealthComponent health = DamagedObject.GetComponent<HealthComponent>();
        if (health)
        {
            health.ApplyDamage(Damage);
        }
    }
}

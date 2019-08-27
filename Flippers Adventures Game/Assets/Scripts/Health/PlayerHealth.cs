using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthComponent
{
    // no need to add ApplyDamage as it does not need to modify

    protected override void Death()
    {
        gameObject.SetActive(false);
        base.Death();
    }
}

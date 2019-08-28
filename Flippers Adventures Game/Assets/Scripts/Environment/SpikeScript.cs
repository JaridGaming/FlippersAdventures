using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    //void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Player" || other.name == "Player")
    //    {
    //        GameplayStatics.DealDamage(other.gameObject, 1);
    //    }
    //}

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player" || other.collider.name == "Player")
        {
            GameplayStatics.DealDamage(other.gameObject, 1);
        }
    }
}

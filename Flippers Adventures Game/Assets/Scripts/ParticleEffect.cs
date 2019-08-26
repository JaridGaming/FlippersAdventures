using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    [SerializeField] float lifeTime = 1.0f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}

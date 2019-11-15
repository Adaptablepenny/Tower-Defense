using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int hitPoints = 10;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnParticleCollision(GameObject enemy)
    {
        print("Hit");
        hitPoints--;
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }

    }
}




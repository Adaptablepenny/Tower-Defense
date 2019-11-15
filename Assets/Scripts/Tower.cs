using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    GameObject turret, enemy, bullet;
    // Update is called once per frame
    void Start()
    {
        FindGameObjects();
    }

    

    void Update()
    {
        if (enemy)
        {
            CheckDistanceAndFire();
        }
        else
        {
            ShootBullet(false);
        }

    }

    private void CheckDistanceAndFire()
    {
        var distance = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
        if (distance <= 20)
        {
            ShootBullet(true);
            turret.transform.LookAt(enemy.transform);
        }
        else
        {
            ShootBullet(false);
        }
    }

    void ShootBullet(bool isActive)
    {
        var fire = bullet.GetComponent<ParticleSystem>().emission;
        fire.enabled = isActive;
    }
    
    private void FindGameObjects()
    {
        bullet = GameObject.Find("/Tower/Turret/Bullet");
        turret = GameObject.Find("/Tower/Turret");
        enemy = GameObject.Find("Enemy");
    }
  
}

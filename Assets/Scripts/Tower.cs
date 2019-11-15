using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    GameObject turret, enemy, bullet;
    // Update is called once per frame
    void Start()
    {
        bullet = GameObject.Find("/Tower/Turret/Bullet");
        turret = GameObject.Find("/Tower/Turret");
        enemy = GameObject.Find("Enemy");
    }
    void Update()
    {
        ShootBullet();
        turret.transform.LookAt(enemy.transform);
       
    }

    void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var shoot = bullet.GetComponent<ParticleSystem>().emission;
            shoot.enabled = enabled;
        }
       
    }
  
}

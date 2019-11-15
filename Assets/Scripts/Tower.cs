﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    GameObject turret, Enemies, bullet;
    Transform enemy;
    // Update is called once per frame
    void Start()
    {
        FindGameObjects();
        FindTransform();
    }

    

    void Update()
    {
        SetTargetEnemy();
        if (enemy)
        {
            CheckDistanceAndFire();
        }
        else
        {
            ShootBullet(false);
        }

    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyMovement>();
        if (sceneEnemies.Length == 0) { return;  }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyMovement enemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, enemy.transform);
        }
        enemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distA = Vector3.Distance(transform.position, transformA.position);
        var distB = Vector3.Distance(transform.position, transformB.position);
        
        if (distA < distB)
        {
            return transformA;
        }

        return transformB;
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
        Enemies = GameObject.Find("Enemies");
    }

    void FindTransform()
    {
        enemy = Enemies.transform.Find("Enemy");
    }
  
}

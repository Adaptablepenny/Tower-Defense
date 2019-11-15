using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] GameObject turret;
    [SerializeField] GameObject enemies;
    [SerializeField] GameObject bullet;
    Transform enemy;
    // Update is called once per frame
    void Start()
    {
        
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
  
}

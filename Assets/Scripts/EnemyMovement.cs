using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float movementSpeed = .5f;
    PathFinder pathfinder;
    Base mainBase;
    [SerializeField] ParticleSystem deathExplosion;



    // Start is called before the first frame update
    void Start()
    {
        pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();       
        StartCoroutine(FollowPath(path));
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FollowPath(List<Waypoint> path)//Moves the enemy along a path determined by the List Waypoint
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementSpeed);
        }
        if (transform.position == pathfinder.GetEndwaypoint().transform.position )
        {
            
            KillEnemy();
            Destroy(gameObject);

        }
    }

    private void KillEnemy()
    {
        
        var deathfx = Instantiate(deathExplosion, transform.position, Quaternion.identity);
        deathfx.Play();
        Destroy(gameObject);
    }
}

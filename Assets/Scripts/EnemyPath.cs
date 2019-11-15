using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
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

            transform.position = new Vector3(waypoint.transform.position.x,transform.position.y,waypoint.transform.position.z);
            yield return new WaitForSeconds(1.75f);
        }
    }
}

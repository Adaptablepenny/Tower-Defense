using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FollowPath()//Moves the enemy along a path determined by the List Waypoint
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("Waypoint: " + waypoint.name);
            yield return new WaitForSeconds(1);
        }
    }
}

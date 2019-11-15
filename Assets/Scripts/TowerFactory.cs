using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    int towerLimit = 5;
    [SerializeField] Tower tower;
    

    Queue<Tower> towerQueue = new Queue<Tower>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTower(Waypoint waypoint)
    {
        //check queue size
        if (towerQueue.Count < towerLimit)
        {
            SpawnTower(waypoint);
        }
        else
        {
            MoveTower(waypoint);
        }
        
    }

    private void SpawnTower(Waypoint waypoint)
    {
        var newTower = Instantiate(tower, waypoint.transform.position, Quaternion.identity);//Spawns in tower
        waypoint.isBlocked = true;// tells the waypoint it can no longer be built on
        towerQueue.Enqueue(newTower);//adds tower to the queue
        newTower.baseWaypoint = waypoint;// tells the new spawned tower its waypoint is equal that of which it was built on
        print(towerQueue.Count);//debugging, tracks queue count
    }

    void MoveTower(Waypoint newWaypoint)
    {
        var oldTower = towerQueue.Dequeue();//take bottom tower off queue
        oldTower.baseWaypoint.isBlocked = false;//unblock waypoint that the tower was on to build on it again
        newWaypoint.isBlocked = true; //makes the new waypoint blocked so it can't built on
        oldTower.baseWaypoint = newWaypoint; //tells the tower where it is going to move to
        oldTower.transform.position = newWaypoint.transform.position; // actually moves it
        towerQueue.Enqueue(oldTower);//puts the tower back into the queue
        
    }
}

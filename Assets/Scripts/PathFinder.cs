using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.right, Vector2Int.left };
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();        
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            print("Searching from: " + searchCenter);
            HaltIfEndFound();
            ExploreNeighbours();
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            print("Halting Search");
            isRunning = false;
        }
    }

    public void ExploreNeighbours()
    {
        if (!isRunning) { return;  }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = searchCenter.GetGridPos() + direction;
            try
            {
                NewNeighbour(neighbourCoords);
            }
            catch
            {
                //nothing
            }
            
        }
    }

    private void NewNeighbour(Vector2Int neighbourCoords)
    {
        Waypoint neighbour = grid[neighbourCoords];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {

        }
        else
        {
            neighbour.SetTopColor(Color.blue);
            print("Adding to queue: " + neighbour);
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
        
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.red);
        endWaypoint.SetTopColor(Color.green);
    }

    private void LoadBlocks()
    {
        var arrayWaypoints = FindObjectsOfType<Waypoint>();

        foreach(Waypoint waypoint in arrayWaypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.Log("Skipping overlapping Block" + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
                waypoint.SetTopColor(Color.yellow);
                
            }
            
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

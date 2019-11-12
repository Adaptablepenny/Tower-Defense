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
    public List<Waypoint> path = new List<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreathPath();
    }

    private void CreathPath()
    {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
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

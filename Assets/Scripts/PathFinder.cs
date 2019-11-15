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
    List<Waypoint> path = new List<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
    }

    public List<Waypoint>GetPath()
    {
        if (path.Count  == 0 )
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
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
            isRunning = false;
        }
    }

    public void ExploreNeighbours()
    {
        if (!isRunning) { return;  }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoords))
            {
                NewNeighbour(neighbourCoords);
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
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
        
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
            }
            
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

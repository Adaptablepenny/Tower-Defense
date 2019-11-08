using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.right, Vector2Int.left };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbours();
        PrintGridValues();
        
    }

    public void ExploreNeighbours()
    {
        
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoords = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[explorationCoords].SetTopColor(Color.blue);
            }
            catch
            {
                //nothing
            }
            
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

    void PrintGridValues()
    {
        foreach (Waypoint waypoint in grid.Values)
        {
            print(waypoint.name);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

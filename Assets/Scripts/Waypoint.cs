using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int GetGridSize()//Just returns the gridsize so it can be accessed by other classes
    {
        return gridSize;
    }

    public Vector2 GetGridPos() //Gets the position of the grid and allows snaping of the GameObject in units * whatever the grid size is
    {
        return new Vector2Int
            (
                gridPos.x = Mathf.RoundToInt(transform.position.x / 10f) * gridSize,
                gridPos.y = Mathf.RoundToInt(transform.position.z / 10f) * gridSize
            );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    [SerializeField] Tower tower;
    public bool isBlocked = false;
    [SerializeField] Transform parent;

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

    public Vector2Int GetGridPos() //Gets the position of the grid and allows snaping of the GameObject in units * whatever the grid size is
    {
        return new Vector2Int
            (
                gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize),
                gridPos.y = Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !isBlocked)
        {
            SpawnTower();
            print(gameObject.name);
            isBlocked = true;
        }
        
    }

    void SpawnTower()
    {
        GameObject newTower = Instantiate(tower.gameObject, transform.position,Quaternion.identity);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}

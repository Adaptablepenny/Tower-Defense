using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{

    

    Waypoint waypoint;
    
    
    void Awake()
    {
        waypoint = GetComponent<Waypoint>();    
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        CubeSnaping();
        LabelText();
        

    }

    private void LabelText()//Updates text on cube with coordinates
    {
        int gridSize = waypoint.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y/ gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }

    private void CubeSnaping() //Snaps cube to grid
    {
        int gridSize = waypoint.GetGridSize();

        transform.position = new Vector3(waypoint.GetGridPos().x, 0f,waypoint.GetGridPos().y);
    }
}

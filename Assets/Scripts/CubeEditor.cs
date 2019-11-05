using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{

    [Range(1f, 20f)] [SerializeField] float gridSize = 10f;

    TextMesh textMesh;
    Vector3 snapPos;
    

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        CubeSnaping();
        LabelText();
        

    }

    private void LabelText()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = snapPos.x / 10f + "," + snapPos.z / 10f;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }

    private void CubeSnaping()
    {
        
        snapPos.x = Mathf.RoundToInt(transform.position.x / 10f) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / 10f) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}

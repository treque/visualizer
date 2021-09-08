using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizedMesh : MonoBehaviour
{
    // Start is called before the first frame update

    Mesh _mesh;
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter)
        {
            _mesh = meshFilter.mesh;
            _mesh.MarkDynamic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

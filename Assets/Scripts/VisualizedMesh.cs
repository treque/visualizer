using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizedMesh : MonoBehaviour
{
    // thinking of loading all the meshes outside the cube and just swapping positions

    public List<Mesh> AvailableMeshes;
    Mesh _mesh;
    int _currentMeshIndex = 0;
    MeshCollider _meshCollider;


    public List<Material> AvailableMaterials;
    Material _material;
    int _currentMaterialIndex = 0;
    MeshRenderer _meshRenderer;

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter)
        {
            _mesh = meshFilter.mesh;
            _mesh.MarkDynamic();
        }

        _meshCollider = GetComponent<MeshCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    public void SwitchToNextMesh()
    {
        if (_mesh && AvailableMeshes.Count != 0)
        {
            _currentMeshIndex = ++_currentMeshIndex % AvailableMeshes.Count;
            _mesh.Clear();

            Mesh newMesh = AvailableMeshes[_currentMeshIndex];
            _mesh.vertices = newMesh.vertices;
            _mesh.triangles = newMesh.triangles;
            _mesh.uv = newMesh.uv;
            _mesh.RecalculateNormals();
            _mesh.RecalculateTangents();
            _mesh.RecalculateBounds();

            if (_meshCollider) _meshCollider.sharedMesh = newMesh;
        }
    }

    public void SwitchToNextMaterial()
    {
        if (_mesh && AvailableMaterials.Count != 0)
        {
            _currentMaterialIndex = ++_currentMaterialIndex % AvailableMaterials.Count;
            _meshRenderer.material = AvailableMaterials[_currentMaterialIndex];
        }
    }
}

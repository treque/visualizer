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
    int _currentMaterialIndex = 0;
    MeshRenderer _meshRenderer;

    public UnityEngine.UI.Text PositionValue;
    public UnityEngine.UI.Text ScaleValue;
    public UnityEngine.UI.Text RotationValue;
    public UnityEngine.UI.Text MeshValue;
    public UnityEngine.UI.Text MaterialValue;
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
        if (AvailableMaterials.Count > 0) SetMaterial(_currentMaterialIndex);
        if (AvailableMaterials.Count > 0) SetMesh(_currentMeshIndex); 
    }

    private void Update()
    {
        // could call less often..
        if (PositionValue)
        {
            PositionValue.text = transform.position.ToString();
        }
        if (ScaleValue)
        {
            ScaleValue.text = transform.localScale.ToString();
        }
        if (RotationValue)
        {
            RotationValue.text = transform.rotation.eulerAngles.ToString();
        }
        if (MeshValue)
        {
            // TODO: default mesh or check for no mesh
            MeshValue.text = AvailableMeshes[_currentMeshIndex].name;
        }
        if (MaterialValue)
        {
            // TODO: default mat or check for no mat
            MaterialValue.text = AvailableMaterials[_currentMaterialIndex].name;
        }
    }
    public void SwitchToNextMesh()
    {
        if (_mesh && AvailableMeshes.Count != 0)
        {
            _currentMeshIndex = ++_currentMeshIndex % AvailableMeshes.Count;
            SetMesh(_currentMeshIndex);
        }
    }

    public void SwitchToNextMaterial()
    {
        if (_mesh && AvailableMaterials.Count != 0)
        {
            _currentMaterialIndex = ++_currentMaterialIndex % AvailableMaterials.Count;
            SetMaterial(_currentMaterialIndex);
        }
    }

    void SetMaterial(int index)
    {
        _meshRenderer.material = AvailableMaterials[index];
    }

    void SetMesh(int index)
    {
        _mesh.Clear();

        Mesh newMesh = AvailableMeshes[index];
        _mesh.vertices = newMesh.vertices;
        _mesh.triangles = newMesh.triangles;
        _mesh.uv = newMesh.uv;
        _mesh.RecalculateNormals();
        _mesh.RecalculateTangents();
        _mesh.RecalculateBounds();

        if (_meshCollider) _meshCollider.sharedMesh = newMesh;
    }
}

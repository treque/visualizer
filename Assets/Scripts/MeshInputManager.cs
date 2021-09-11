using UnityEngine;
using UnityEngine.InputSystem;

public class MeshInputManager : MonoBehaviour
{
    public enum MeshTransformState
    {
        None,
        Translate,
        Rotate,
        Scale
    }

    [HideInInspector]
    public MeshTransformState TransformState;
    // make a setter for toggling to none

    public VisualizedMesh VisualizedMesh;
    TransformData _originalMeshTransform;

    Camera _camera;

    public float MouseDragSpeed = 0.02f;
    void Start()
    {
        _camera = Camera.main;
        if (VisualizedMesh)
        {
            _originalMeshTransform = new TransformData
            {
                position = VisualizedMesh.transform.position,
                rotation = VisualizedMesh.transform.rotation,
                localScale = VisualizedMesh.transform.localScale
            };
        }
    }
    public void ChangeMesh()
    {
        VisualizedMesh.SwitchToNextMesh();
    }
    public void ChangeMaterial()
    {
        VisualizedMesh.SwitchToNextMaterial();
    }
    public void OnMouseDrag(InputAction.CallbackContext context)
    {
        // TODO: Constraint to volume
        if (TransformState != MeshTransformState.None && Mouse.current.leftButton.isPressed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            switch (TransformState)
            {
                case MeshTransformState.Translate:
                    Vector3 up = _camera.transform.up;
                    Vector3 right = _camera.transform.right;
                    input *= MouseDragSpeed;
                    VisualizedMesh.transform.position = VisualizedMesh.transform.position
                                                        +  (up * input.y) + (right * input.x);
                    break;
                case MeshTransformState.Scale:
                    // hard problem 
                    input *= MouseDragSpeed;
                    if (input.y < 0 || input.x < 0)
                        VisualizedMesh.transform.localScale = VisualizedMesh.transform.localScale
                                                        - new Vector3(input.magnitude, input.magnitude, input.magnitude);
                    else
                        VisualizedMesh.transform.localScale = VisualizedMesh.transform.localScale
                                                        + new Vector3(input.magnitude, input.magnitude, input.magnitude);
                    break;
                case MeshTransformState.Rotate:
                    up = _camera.transform.up;
                    right = _camera.transform.right;
                    VisualizedMesh.transform.Rotate(((right * input.y) - (up * input.x)), Space.World);
                    break;
            }
        }
    }
    public void ResetMesh()
    {
        VisualizedMesh.transform.position = _originalMeshTransform.position;
        VisualizedMesh.transform.rotation = _originalMeshTransform.rotation;
        VisualizedMesh.transform.localScale = _originalMeshTransform.localScale;
        // TODO: reset mats and all
    }
}

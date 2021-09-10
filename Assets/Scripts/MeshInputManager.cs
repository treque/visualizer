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

    public VisualizedMesh VisualizedMesh;
    TransformData _originalMeshTransform;

    Vector2 _mousePosition;
    Camera _camera;
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
    public void OnMouseMove(InputAction.CallbackContext context)
    {
        _mousePosition = context.ReadValue<Vector2>();
    }
    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(_mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.gameObject.GetComponent<VisualizedMesh>()) // later -- interactible interface (change lights, or pp)
                {
                    VisualizedMesh.SwitchToNextMesh();
                }
            }
        }

    }
    public void OnMouseDrag(InputAction.CallbackContext context)
    {
        if (context.performed && TransformState != MeshTransformState.None)
        {
            switch (TransformState)
            {
                case MeshTransformState.Translate:
                    VisualizedMesh.transform.position = VisualizedMesh.transform.position + Vector3.one;
                    break;
                case MeshTransformState.Scale:
                    break;
                case MeshTransformState.Rotate:
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

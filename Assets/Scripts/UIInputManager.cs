using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    public MeshInputManager TransformInputManager;

    Camera _mainCamera;
    TransformData _originalCameraTransform;
    void Start()
    {
        _mainCamera = Camera.main;
        _originalCameraTransform = new TransformData
        {
            position = _mainCamera.transform.position,
            rotation = _mainCamera.transform.rotation,
            localScale = _mainCamera.transform.localScale
        };
    }
    public void OnResetCamera()
    {
        // being overidden by simplecameracontroller.. either fix it or drop the feature
        _mainCamera.transform.position = _originalCameraTransform.position;
        _mainCamera.transform.rotation = _originalCameraTransform.rotation;
    }
    public void OnResetMesh()
    {
        TransformInputManager.ResetMesh();
    }
    public void OnTranslateSelected()
    {
        if (TransformInputManager)
        {
            TransformInputManager.TransformState = MeshInputManager.MeshTransformState.Translate;
        }
    }
    public void OnRotateSelected()
    {
        if (TransformInputManager)
        {
            TransformInputManager.TransformState = MeshInputManager.MeshTransformState.Rotate;
        }
    }
    public void OnScaleSelected()
    {
        // find way to toggle in UI
        if (TransformInputManager)
        {
            TransformInputManager.TransformState = MeshInputManager.MeshTransformState.Scale;
        }
    }
}

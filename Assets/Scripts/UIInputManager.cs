using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    public MeshInputManager MeshInputManager;
    public UnityTemplateProjects.SimpleCameraController CameraController;

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
        if (CameraController)
        {
            CameraController.ResetCameraTransform();
        }
    }
    public void OnResetMesh()
    {
        MeshInputManager.ResetMesh();
    }
    public void OnTranslateSelected()
    {
        if (MeshInputManager)
        {
            MeshInputManager.TransformState = MeshInputManager.MeshTransformState.Translate;
        }
    }
    public void OnRotateSelected()
    {
        if (MeshInputManager)
        {
            MeshInputManager.TransformState = MeshInputManager.MeshTransformState.Rotate;
        }
    }
    public void OnScaleSelected()
    {
        // find way to toggle in UI
        if (MeshInputManager)
        {
            MeshInputManager.TransformState = MeshInputManager.MeshTransformState.Scale;
        }
    }

    public void OnChangeMeshSelected()
    {
        MeshInputManager.ChangeMesh();
    }

    public void OnChangeMaterialSelected()
    {
        MeshInputManager.ChangeMaterial();
    }
}

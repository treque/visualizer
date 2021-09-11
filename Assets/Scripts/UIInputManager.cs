using UnityEngine;
using UnityEngine.UI;

public class UIInputManager : MonoBehaviour
{
    public MeshInputManager MeshInputManager;
    public UnityTemplateProjects.SimpleCameraController CameraController;
    public Button TranslateButton;
    public Button RotateButton;
    public Button ScaleButton;
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
        if (MeshInputManager && TranslateButton)
        {
            bool isEnabled = MeshInputManager.TransformState == MeshInputManager.MeshTransformState.Translate;
            MeshInputManager.TransformState = isEnabled ? 0 : MeshInputManager.MeshTransformState.Translate;
            SetButtonEnabled(TranslateButton, !isEnabled);
        }
    }
    public void OnRotateSelected()
    {
        if (MeshInputManager && RotateButton)
        {
            bool isEnabled = MeshInputManager.TransformState == MeshInputManager.MeshTransformState.Rotate;
            MeshInputManager.TransformState = isEnabled ? 0 : MeshInputManager.MeshTransformState.Rotate;
            SetButtonEnabled(RotateButton, !isEnabled);
        }
    }
    public void OnScaleSelected()
    {
        if (MeshInputManager && ScaleButton)
        {
            bool isEnabled = MeshInputManager.TransformState ==  MeshInputManager.MeshTransformState.Scale;
            MeshInputManager.TransformState = isEnabled ? 0 : MeshInputManager.MeshTransformState.Scale;
            SetButtonEnabled(ScaleButton, !isEnabled);
        }
    }


    // Toggles to grey if enabled
    void SetButtonEnabled(Button button, bool enable)
    {
        // disable the other ones, find way to maybe use flags or something to disable the right ones
        TranslateButton.image.color = Color.white;
        RotateButton.image.color = Color.white;
        ScaleButton.image.color = Color.white;
        if (enable)
        {
            button.image.color = Color.grey;
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

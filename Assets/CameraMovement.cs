using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame

    public VisualizedMesh VisualizedMesh;
    Vector2 _mousePosition;
    bool _isRotating;
    Camera _camera;
    void Start()
    {
        _camera = Camera.main;
    }


    public void OnMouseMove(InputAction.CallbackContext context)
    {
        _mousePosition = context.ReadValue<Vector2>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        this.transform.position += new Vector3(input.x, input.y, 0); // fix to be relative to camera lookat
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        /*if (context.started)
        {
            Debug.Log("Hold");
        }
        else
        {
            Debug.Log("Stop");
        }*/
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

    private void ResetPosition()
    {
        _camera.transform.localRotation = Quaternion.identity;
        transform.position = Vector3.zero;
    }
}

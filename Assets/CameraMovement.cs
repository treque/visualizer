using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("MOVE");
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        Debug.Log("Rotate");
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        Debug.Log("Select");
    }
}

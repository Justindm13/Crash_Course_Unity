using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShiftPlatform : MonoBehaviour
{
    Transform platform;
    bool platformRotated;

    private void Start() {
        platform = GetComponent<Transform>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        
        if (context.performed && platformRotated==true)
        {
        platform.Rotate(0,0,-16);
        platformRotated=false;
        Debug.Log(platformRotated);
        }
        else if (context.performed && platformRotated==false)
        {
        platform.Rotate(0,0,16);
        platformRotated=true;
        Debug.Log(platformRotated);
        }
    }
}

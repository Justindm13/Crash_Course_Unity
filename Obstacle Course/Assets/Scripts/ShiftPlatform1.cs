using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShiftPlatform1 : MonoBehaviour
{
    // public Vector3 startingRotation;
    public bool UpwardsRotation;
    public bool DownwardsRotation;
    [SerializeField] float speed = 4f;

    private void FixedUpdate()
    {
        RotatePlatform();
    }

    void RotatePlatform()
    {
        if(DownwardsRotation==true)
        {
            if (transform.eulerAngles.z>172)
            {
              transform.Rotate(new Vector3(0, 0, -16) * speed * Time.deltaTime);
            }
            else {
                DownwardsRotation=false;
            }

        }

        if(UpwardsRotation==true)
        {
            if (transform.eulerAngles.z<188)
            {
              transform.Rotate(new Vector3(0, 0, 16) * speed * Time.deltaTime);
            }
            else
            {
                UpwardsRotation=false;
            }
        }
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DownwardsRotation=true;
        } 
        else
        {
            DownwardsRotation=false;
        }
        
        if (context.canceled)
        {
            UpwardsRotation=true;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShiftPlatform : MonoBehaviour
{
    // public Vector3 startingRotation;
    public bool UpwardsRotation;
    public bool DownwardsRotation;
    [SerializeField] float speed = 30f;

    private void Start() 
    {
        // transform.eulerAngles = startingRotation;
    }

    private void Update()
    {
        RotatePlatform();
    }

    void RotatePlatform()
    {
        if (UpwardsRotation==true)
        {
            if (transform.eulerAngles.z>172)
            {
              transform.Rotate(Vector3.back,speed * Time.deltaTime); 
            }
            else {
                UpwardsRotation=false;
            }
            
        }

        if (DownwardsRotation==true)
        {
           if (transform.eulerAngles.z<188)
            {
              transform.Rotate(Vector3.forward,speed * Time.deltaTime); 
            }
            else
            {
                DownwardsRotation=false;
            }
        }
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && transform.eulerAngles.z>186 && DownwardsRotation==false)
        {
            Debug.Log("first box");
            UpwardsRotation=true;
        }
          if (context.performed && transform.eulerAngles.z>170 && UpwardsRotation==false)
        {
            Debug.Log("second box");
            DownwardsRotation=true;
        }
    }
}

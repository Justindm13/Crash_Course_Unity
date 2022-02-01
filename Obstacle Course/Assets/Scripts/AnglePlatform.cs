using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnglePlatform : MonoBehaviour
{
  public bool UpwardsRotation;
  public bool DownwardsRotation;
  [SerializeField] float speed = 30f;

    private void Update()
    {
        RotatePlatform();
    }

    void RotatePlatform()
    {
        if (UpwardsRotation==true)
        {
            if (transform.eulerAngles.z>0.2)
            {
              transform.Rotate(Vector3.back,speed * Time.deltaTime); 
            }
            else {
                UpwardsRotation=false;
            }
            
        }

        if (DownwardsRotation==true)
        {
           if (transform.eulerAngles.z<31)
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
        if (context.performed && transform.eulerAngles.z>30 && DownwardsRotation==false)
        {
            Debug.Log("first box");
            UpwardsRotation=true;
        }
          if (context.performed && transform.eulerAngles.z>0 && UpwardsRotation==false)
        {
            Debug.Log("second box");
            DownwardsRotation=true;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnglePlatform : MonoBehaviour
{
  public bool UpwardsRotation;
  public bool DownwardsRotation;
  [SerializeField] float speed = 2f;

    private void FixedUpdate()
    {
        RotatePlatform();
    }

    void RotatePlatform()
    {
        if (UpwardsRotation==true)
        {
            if (transform.eulerAngles.z>180)
            {
              transform.Rotate(new Vector3(0, 0, -30) * speed * Time.deltaTime);
            }
            else {
                UpwardsRotation=false;
            }
            
        }

        if (DownwardsRotation==true)
        {
           if (transform.eulerAngles.z<210)
            {
              transform.Rotate(new Vector3(0, 0, 30) * speed * Time.deltaTime);
            }
            else
            {
                DownwardsRotation=false;
            }
        }
        
        if (transform.eulerAngles.z<190 && DownwardsRotation==false && UpwardsRotation==false) // fixes a bug where the platforms don't correctly line up after the car interacts with them. 
        {
            transform.eulerAngles=new Vector3(0,0,180);
        }
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("first box");
            DownwardsRotation=true;
        } 
        else
        {
            DownwardsRotation=false;
        }
        
        if (context.canceled)
        {
            Debug.Log("second box");
            UpwardsRotation=true;
        }
    }
}


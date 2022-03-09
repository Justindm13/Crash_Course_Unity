using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CircleRotatingPlatform : MonoBehaviour
{
  [SerializeField] bool UpwardsRotation;
  [SerializeField] bool DownwardsRotation;
  public Rigidbody2D rotationPoint;
  [SerializeField] float speed = .75f;

    private void FixedUpdate()
    {
      RotatePlatform();
    }

    void RotatePlatform()
    {
      /*
        Debug.Log(transform.eulerAngles.z);
        if(transform.eulerAngles.z == 0){
          Debug.Log("Rotate Left!");
          transform.RotateAround(rotationPoint.position, new Vector3(0, 0, 1) * speed * Time.deltaTime, -180);
        }
        else if(transform.eulerAngles.z != 0){
          if(transform.eulerAngles.z == 180){
            Debug.Log("Rotate Right!");
            transform.RotateAround(rotationPoint.position, new Vector3(0, 0, 1) * speed * Time.deltaTime, 180);
          }
        }
      */
        if(DownwardsRotation==true)
        {
            if (transform.eulerAngles.z < 356)
            {
              transform.RotateAround(rotationPoint.position, new Vector3(0, 0, 1), 180*speed*Time.deltaTime);
            }
            else {
              DownwardsRotation=false;
            }

        }

        if(UpwardsRotation==true)
        {
            if (transform.eulerAngles.z > 30)
            {
              transform.RotateAround(rotationPoint.position, new Vector3(0, 0, 1), -180*speed*Time.deltaTime);
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
            UpwardsRotation=true;
            DownwardsRotation=false;
        }
        else
        {
            UpwardsRotation=false;
        }

        if (context.canceled)
        {
            DownwardsRotation=true;
        }
    }
}

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
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && transform.eulerAngles.z>208 && DownwardsRotation==false)
        {
            Debug.Log("first box");
            UpwardsRotation=true;
        }
          if (context.performed && transform.eulerAngles.z<182 && UpwardsRotation==false)
        {
            Debug.Log("second box");
            DownwardsRotation=true;
        }
    }
}


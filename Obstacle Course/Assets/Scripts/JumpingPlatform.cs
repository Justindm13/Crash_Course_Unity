using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpingPlatform : MonoBehaviour
{
    Rigidbody2D platform;
    [SerializeField] float thrust;

    private void Start() {
        platform = GetComponent<Rigidbody2D>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
        Debug.Log("Jumped Platform" + context.phase);
        platform.AddForce(new Vector3(0, thrust, 0), ForceMode2D.Impulse); 
        }
    }
}

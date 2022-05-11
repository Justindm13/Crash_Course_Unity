using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpingPlatform : MonoBehaviour
{
    Rigidbody2D platform;
    public CircleCollider2D leftWheel;
    public CircleCollider2D rightWheel;
    public BoxCollider2D spring;
    [SerializeField] float thrust;

    private void Start() {
        platform = GetComponent<Rigidbody2D>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(spring.IsTouching(leftWheel) || spring.IsTouching(rightWheel)) {
                Debug.Log("Jumped Platform" + context.phase);
                platform.AddForce(new Vector3(0, thrust, 0), ForceMode2D.Impulse);
            }
        }
    }
}

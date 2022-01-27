using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    public bool platformTriggered;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Drive();
    }

    void OnJump (InputValue value)
    {
        if (value.isPressed)
        {
          Debug.Log(platformTriggered);
          platformTriggered = true;
        } 
        else
        {
         Debug.Log("released jump");
         platformTriggered = false;
        }  
        
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Drive()
    {
        Vector2 carVelocity = new Vector2 (moveInput.x, 0f);
        myRigidbody.velocity = carVelocity * moveSpeed;
        
    }

}

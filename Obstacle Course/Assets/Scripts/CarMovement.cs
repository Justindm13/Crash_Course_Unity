using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    GameManager gameManager;

    [Header("Speed")]
    [SerializeField] float moveSpeed = 250f;

    [Header("Player Settings")]
    [SerializeField] bool canDie = false;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        Drive();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Drive()
    {
        //Vector2 carVelocity = new Vector2 (moveInput.x, carVelocity.y).normalized * moveSpeed;
        if (Input.GetKey("d") || Input.GetKey("a"))
        {
        myRigidbody.AddForce(new Vector2(moveInput.x, 0).normalized * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
        else
        {
        myRigidbody.AddForce(new Vector2(moveInput.x/2, 0).normalized * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
      moveSpeed = 450f;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        moveSpeed = 250f;
    }
}

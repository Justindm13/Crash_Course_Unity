using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTracker : MonoBehaviour
{
    CircleCollider2D deathTracker;
    GameManager gameManager;
    public bool isAlive=true;
    public GameObject leftWheel;
    public GameObject rightWheel;
    public GameObject head;


    private void Start() {
        deathTracker = GetComponent<CircleCollider2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if(head.transform.position.y < leftWheel.transform.position.y && head.transform.position.y < rightWheel.transform.position.y) {
        Debug.Log("You just died");
        isAlive=false;
      }
    }

    public bool GetDeathStatus()
    {
        return isAlive;
    }

    public bool ResetDeathStatus()
    {
        isAlive=true;
        return isAlive;
    }

}

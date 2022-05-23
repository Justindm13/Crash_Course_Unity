using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTracker : MonoBehaviour
{
    CircleCollider2D deathTracker;
    GameManager gameManager;
    public bool isAlive=true;


    private void Start() {
        deathTracker = GetComponent<CircleCollider2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Ground")
        {
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

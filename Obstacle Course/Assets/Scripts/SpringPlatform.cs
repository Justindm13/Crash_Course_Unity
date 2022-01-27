using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    [SerializeField] float thrust;
    CarMovement carMovement;
    Rigidbody2D platform;

    private void Start() {
        platform = GetComponent<Rigidbody2D>();
        carMovement = FindObjectOfType<CarMovement>();
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
      if (other.tag == "Car" && carMovement.platformTriggered==true)
      {
       Debug.Log("Triggered");
       platform.AddForce(new Vector3(0, thrust, 0), ForceMode2D.Impulse); 
      }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    [SerializeField] float thrust;
    Rigidbody2D platform;
    bool hasTriggered;

    private void Start() {
        platform = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
       
      if (other.tag == "Car" && hasTriggered==false)
      {
       Debug.Log("Triggered");
       platform.AddForce(new Vector3(0, thrust, 0), ForceMode2D.Impulse); 
       hasTriggered=true;
      }
    }

}

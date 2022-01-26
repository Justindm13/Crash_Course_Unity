using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
   [SerializeField] float moveSpeed = 15f;

    private void Start() 
    {
    
    }

   void Update()
   {   
        float moveAmount = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(moveAmount, 0, 0);
   }
}

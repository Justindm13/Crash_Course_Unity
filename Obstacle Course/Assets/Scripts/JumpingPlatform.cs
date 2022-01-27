using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlatform : MonoBehaviour
{
    Rigidbody2D platform;
    [SerializeField] float thrust;

    private void Start() {
        platform = GetComponent<Rigidbody2D>();
    }
    public void Jump()
    {
        Debug.Log("Jumped Platform");
        platform.AddForce(new Vector3(0, thrust, 0), ForceMode2D.Impulse); 
    }
}

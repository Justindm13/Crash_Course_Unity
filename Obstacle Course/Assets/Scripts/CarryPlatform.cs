using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryPlatform : MonoBehaviour
{
  public GameObject platformPathStart;
  public GameObject platformPathEnd;
  public CircleCollider2D leftWheel;
  public CircleCollider2D rightWheel;
  public BoxCollider2D carryPlatform;
  private Vector3 startPosition;
  private Vector3 endPosition;
  public float moveSpeed;

  IEnumerator Vector3LerpCoroutine(GameObject obj, Vector3 target, float speed){
      Vector3 startPosition = obj.transform.position;
      float time = 0f;
      while(obj.transform.position != target)
      {
          obj.transform.position = Vector3.Lerp(startPosition, target, (time/Vector3.Distance(startPosition, target))*moveSpeed);
          time += Time.deltaTime;
          yield return null;
      }
  }


  void Start()
  {
    startPosition = platformPathStart.transform.position;
    endPosition = platformPathEnd.transform.position;
  }

  void Update()
  {
  }

  void OnCollisionEnter2D(Collision2D col){
      if(col.collider.CompareTag("Car")){
          if(carryPlatform.IsTouching(leftWheel) && carryPlatform.IsTouching(rightWheel)) {
              col.gameObject.transform.parent.SetParent(gameObject.transform,true);
              StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, moveSpeed));
          }
      }
  }
  void OnCollisionExit2D(Collision2D col)
   {
      if(!carryPlatform.IsTouching(leftWheel) || !carryPlatform.IsTouching(rightWheel)) {
        col.gameObject.transform.parent.SetParent(null);
      }
   }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveBehavior : MonoBehaviour
{
  EnemyAttribute enemy;
   public float speed = 5f;
   public int damage = 0;
 
  void Update()
  {
     transform.Translate(Vector3.right * speed * Time.deltaTime);
  }
   void OnCollisionEnter2D(Collision2D col)
   {
    if(col.gameObject.tag == "enemy" || col.gameObject.tag == "Platform" || col.gameObject.tag == "Ground" ) 
    {
      Vector2 knockbackDirection = (enemy.transform.position - transform.position).normalized;
      enemy.TakeDam(damage,knockbackDirection);
      Destroy(this);
    }
   }
}

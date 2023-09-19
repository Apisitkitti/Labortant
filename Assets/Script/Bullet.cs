using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Player player;
    int damage = 15;
    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.tag == "Player"  )
      {
        player.TakeDam(damage);
        Destroy(gameObject);
      }
      if(col.gameObject.tag == "Platform"|| col.gameObject.tag == "Ground")
      {
        Destroy(gameObject);
      }
    }
}

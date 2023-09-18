using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    public int damage = 10;
    public Player player;
    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.tag == "Player")
      {
        player = col.GetComponent<Player>();
        if(player != null)
        {
          player.TakeDam(damage);
        }
      }
    }
}

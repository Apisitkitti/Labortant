using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDam : MonoBehaviour
{
   public int damage = 10;
    public Player player;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player = col.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDam(10);
            }
        }
    }
}

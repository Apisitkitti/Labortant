using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDam : MonoBehaviour
{
   public int damage = 0;
    public Player player;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player = col.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDam(damage);
                Debug.Log(damage);
            }
        }
    }
}
